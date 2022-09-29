# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_C/review/3047642/mamurai/Python3
base1 = 1009
base2 = 1013
mask = (1 << 32) - 1

def calculate_hash(f, r, c):
    global ph, pw, h
    tmp = [[0 for _ in range(c)] for _ in range(r)]
    dr, dc = r - ph, c - pw

    t1 = 1
    for _ in range(pw):
        t1 = (t1 * base1) & mask
    for i in range(r):
        e = 0
        for j in range(pw):
            e = e * base1 + f[i][j]
        for j in range(dc):
            tmp[i][j] = e
            e = (e * base1 - t1 * f[i][j] + f[i][j + pw]) & mask
        tmp[i][dc] = e

    t2 = 1
    for _ in range(ph):
        t2 = (t2 * base2) & mask
    for j in range(dc + 1):
        e = 0
        for i in range(ph):
            e = e * base2 + tmp[i][j]
        for i in range(dr):
            h[i][j] = e
            e = (e * base2 - t2 * tmp[i][j] + tmp[i + ph][j]) & mask
        h[dr][j] = e

th, tw = map(int, input().split())
t = [[ord(x) for x in input().strip()] for _ in range(th)]
ph, pw = map(int, input().split())
p = [[ord(x) for x in input().strip()] for _ in range(ph)]

if th >= ph and tw >= pw:
    h = [[0 for _ in range(tw)] for _ in range(th)]
    calculate_hash(p, ph, pw)
    key = h[0][0] & mask
    calculate_hash(t, th, tw)
    for i in range(th - ph + 1):
        for j in range(tw - pw + 1):
            if h[i][j] & mask == key:
                print(i, j)
