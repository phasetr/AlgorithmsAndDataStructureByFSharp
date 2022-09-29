# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_D/review/6385264/junonishizaki/Python3
import bisect

t = input()
l = []
for i in range(len(t)):
    l.append(t[i:i + 1000])
l.sort()

q = int(input())
for _ in range(q):
    p = input()

    i = bisect.bisect_left(l, p)
    if i == len(t):
        print(0)
    else:
        print(1 if l[i].find(p) >= 0 else 0)
