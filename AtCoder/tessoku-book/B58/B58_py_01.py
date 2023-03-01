# https://atcoder.jp/contests/tessoku-book/submissions/39041898
import bisect

n, l, r = map(int, input().split())
x = [int(i) for i in input().split()]

INF = 10 ** 10
size = 18
seg = [INF] * (1 << (size + 1))

def update(pos, x):
  pos += 1 << size
  seg[pos] = x
  while pos > 1:
    pos //= 2
    seg[pos] = min(seg[2*pos], seg[2*pos+1])


def get_min(l, r):
  l += 1 << size
  r += 1 << size
  ans = INF
  while l < r:
    if l % 2 == 1:
      ans = min(ans, seg[l])
      l += 1
    if r % 2 == 1:
      ans = min(ans, seg[r-1])
      r -= 1
    l //= 2
    r //= 2

  return ans

update(0, 0)
for i in range(1, n):
  left = bisect.bisect_left(x, x[i]-r)
  right = bisect.bisect_right(x, x[i]-l)
  update(i, get_min(left, right) + 1)

print(seg[n-1 + (1<<size)])
