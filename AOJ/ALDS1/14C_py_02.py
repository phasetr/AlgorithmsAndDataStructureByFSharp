# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_C/review/4388923/jakenu0x5e/Python3
import sys
readline = sys.stdin.readline
write = sys.stdout.write

mod = 10**9 + 9; p = 13; q = 19

p_table = q_table = None
def prepare(L):
    global p_table, q_table
    p_table = [1]*(L+1); q_table = [1]*(L+1)
    for i in range(L):
        p_table[i+1] = p_table[i] * p % mod
        q_table[i+1] = q_table[i] * q % mod

def rolling_hash(S, W, H):
    D = [[0]*(W+1) for i in range(H+1)]
    for i in range(H):
        su = 0
        dp = D[i]
        di = D[i+1]
        si = S[i]
        for j in range(W):
            v = si[j] # v = ord(si[j]) if si[j] is str
            su = (su*p + v) % mod
            di[j+1] = (su + dp[j+1]*q) % mod
    return D
def get(S, x0, y0, x1, y1):
    P = p_table[x1 - x0]; Q = q_table[y1 - y0]
    return (S[y1][x1] - S[y1][x0] * P - S[y0][x1] * Q + S[y0][x0] * (P * Q) % mod) % mod

def solve():
    prepare(1001)
    H, W = map(int, readline().split())
    M = [list(map(ord, readline().strip())) for i in range(H)]
    R, C = map(int, readline().split())
    M0 = [list(map(ord, readline().strip())) for i in range(R)]

    rh = rolling_hash(M, W, H)
    rh0 = rolling_hash(M0, C, R)
    v = rh0[-1][-1]
    for i in range(H-R+1):
        for j in range(W-C+1):
            if v == get(rh, j, i, j+C, i+R):
                write("%d %d\n" % (i, j))
solve()
