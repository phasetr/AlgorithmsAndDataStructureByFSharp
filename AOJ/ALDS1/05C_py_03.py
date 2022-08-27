# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_C/review/2710765/kyuna/Python3
d=[0j,100+0j]
for _ in[0]*int(input()):
 p=[d[0]]
 for i in range(len(d)-1):
  a,b=d[i],d[i+1]
  r=(b-a)/3
  p+=[a+r,a+r+r*(1+3**.5*1j)/2,b-r,b]
 d=p
for e in d:print(e.real,e.imag)
