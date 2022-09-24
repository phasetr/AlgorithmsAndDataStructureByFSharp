# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_A/review/2823162/kyuna/Python3
T,P=input(),input()
for i in range(len(T)):P!=T[i:i+len(P)]or print(i)
