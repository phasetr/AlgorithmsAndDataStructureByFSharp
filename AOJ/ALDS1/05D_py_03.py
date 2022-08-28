# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_D/review/1637111/ikatakos/Python3
from collections import deque
INFTY = 1e9 + 1

def merge(a, l, m, r):
    global cnt
    ll = deque(a[l:m])
    rl = deque(a[m:r])
    for k in range(l, r):
        if not rl or ll and ll[0] < rl[0]:
            a[k] = ll.popleft()
        else:
            a[k] = rl.popleft()
            cnt += len(ll)

def merge_sort(a, l, r):
    if l + 1 < r:
        m = (l + r) // 2
        merge_sort(a, l, m)
        merge_sort(a, m, r)
        merge(a, l, m, r)

n, a, cnt = int(input()), list(map(int, input().split())), 0
merge_sort(a, 0, n)
print(cnt)
