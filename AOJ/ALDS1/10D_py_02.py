# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_D/review/3199555/jakenu0x5e/Python3
import sys
readline = sys.stdin.readline
write = sys.stdout.write

N = int(readline())
*P, = map(float, readline().split())
*Q, = map(float, readline().split())

K = [[None]*(N+1) for i in range(N+1)]
C = [[None]*(N+1) for i in range(N+1)]
S = [0]*(2*N+2)
for i in range(2*N+1):
    S[i+1] = S[i] + (P[i//2] if i % 2 else Q[i//2])

for i in range(N+1):
    C[i][i] = Q[i]
    K[i][i] = i

for l in range(1, N+1):
    for i in range(N+1-l):
        j = i+l
        k0 = K[i][j-1]; k1 = K[i+1][j]
        tmp = 1e30
        k2 = None
        for k in range(k0, min(k1+1, j)):
            v = C[i][k] + C[k+1][j]
            if v < tmp:
                k2 = k
                tmp = v
        K[i][j] = k2
        C[i][j] = tmp + (S[2*j+1] - S[2*i])
write("%.10f\n" % C[0][N])
