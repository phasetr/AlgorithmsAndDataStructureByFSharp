# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_D/review/3184136/jakenu0x5e/Python3
import sys
readline = sys.stdin.readline
write = sys.stdout.write

N = int(readline())
*A, = map(int, readline().split())

data = [0]*(N+1)
def add(k, v):
    while k <= N:
        data[k] += v
        k += k & -k
def get(k):
    s = 0
    while k:
        s += data[k]
        k -= k & -k
    return s


ans = N*(N-1)//2
for a in map({a: i+1 for i, a in enumerate(sorted(A))}.__getitem__, A):
    ans -= get(a)
    add(a, 1)
write("%d\n" % ans)
