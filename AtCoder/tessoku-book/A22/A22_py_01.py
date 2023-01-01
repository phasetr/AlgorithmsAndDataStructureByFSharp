#!/usr/bin/env python3
# https://atcoder.jp/contests/tessoku-book/submissions/37656237
n = int(input())
a = list(map(int,input().split()))
b = list(map(int,input().split()))

su = [-99999999] * (n + 1)
su[1] = 0
for i in range(1,n):
  su[a[i - 1]] = max(su[a[i - 1]],su[i] + 100)
  su[b[i - 1]] = max(su[b[i - 1]],su[i] + 150)

print(max(su))
