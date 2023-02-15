# https://atcoder.jp/contests/tessoku-book/submissions/36125562
from bisect import bisect_left

n=int(input())
d=[]
for _ in range(n):
    x,y = map(int,input().split())
    d.append([x,-y])
d.sort()
ans = 0
e=[1<<32]*n

for i in range(n):
    e[bisect_left(e, -d[i][1])] = -d[i][1]
print(bisect_left(e,1<<32))
