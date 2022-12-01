# https://atcoder.jp/contests/tenka1-2018/submissions/12997425
N,*a = map(int,open(0))
n = N//2-1
a.sort()
print(2*sum(a[n+2:])-2*sum(a[:n])+a[n+1]-a[n]-N%2*min(a[~n]+a[n],2*a[n+1]))
