# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP2_1_B/review/3233398/jakenu0x5e/Python3
from collections import deque
readline = open(0).readline
writelines = open(1, 'w').writelines
Q = int(readline())
ans = []
A = deque()
def push(d, x):
    (A.append if d else A.appendleft)(x)
def access(p):
    ans.append("%d\n" % A[p])
def pop(d):
    (A.pop if d else A.popleft)()

C = [push, access, pop].__getitem__
for i in range(Q):
    t, *a=map(int, readline().split())
    C(t)(*a)
writelines(ans)
