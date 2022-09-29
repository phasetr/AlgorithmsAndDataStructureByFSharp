# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_B/review/5261834/noimi/Python3
T = input()
P = input()
for i in range(len(T) - len(P) + 1):
    if T[i : i + len(P)] == P:
        print(i)
