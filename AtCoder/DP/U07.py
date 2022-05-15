# https://atcoder.jp/contests/dp/submissions/31108922
N,*A=map(int,open(0).read().split())
R,*c=range,
for o in R(1<<N):
    t = sum((o>>_//N&o>>_%N&1) * A[_] for _ in R(N*N)); s=o
    while s: s=~-s&o; t=max(t,c[-s]+c[s])
    c+=t
print(t>>1)
