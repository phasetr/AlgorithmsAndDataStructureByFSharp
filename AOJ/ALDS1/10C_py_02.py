# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_C/review/3007511/bs5lNkJ/Python3
ascii_letters = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ'

def llcs(x, y):
    pm = dict((zip(ascii_letters, [0] * 52)))
    for c in pm:
        for i, xc in enumerate(x):
            if c == xc:
                pm[c] |= (1 << i)

    V = (1 << len(x)) - 1
    for yc in y:
        V = ((V + (V & pm[yc])) | (V & ~pm[yc]))
    ans = bin(V)[-len(x):].count('0')
    return ans

from sys import stdin

def solve():
    file_input = stdin
    q = int(file_input.readline())
    for i in range(q):
        s1 = file_input.readline().rstrip()
        s2 = file_input.readline().rstrip()
        print(llcs(s1, s2))

solve()
