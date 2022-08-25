# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_D/review/1126210/giguru/Python
n,k=map(int,raw_input().split())
w=[input() for _ in range(n)]
l=max(w)
r=sum(w)
while l<r:
    m=(l+r)/2
    s=c=0
    for i in w:
        s+=i
        if s>m:s=i;c+=1
    if c<k:r=m
    else:l=m+1
print l
