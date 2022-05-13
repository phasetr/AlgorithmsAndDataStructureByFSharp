# https://atcoder.jp/contests/dp/submissions/31465692
mod = 10 ** 9 + 7
def times(A, B, N):
    C = [[0] * N for _ in range(N)]
    for i in range(N):
        for j in range(N):
            for k in range(N):
                C[i][j] = (C[i][j] + A[i][k] * B[k][j]) % mod
    return C

def exponen(A, k, N):
    if k == 0:
        # 単位行列の生成
        return [[+(i == j) for j in range(N)] for i in range(N)]
    elif k % 2 == 0:
        return exponen(times(A, A, N), k // 2, N)
    else:
        return times(A, exponen(A, k-1, N), N)

def solve(N, K, a):
    X = exponen(a, K, N)
    ans = 0
    for i in range(N):
        for j in range(N):
            ans = (ans + X[i][j]) % mod
    return ans

def main():
    N, K = map(int, input().split())
    a = [[*map(int, input().split())] for _ in range(N)]
    print(solve(N,K,a))

def test():
    N,K,a = (4,2,[[0,1,0,0],[0,0,1,1],[0,0,0,1],[1,0,0,0]])
    print(exponen(a,K,N))
    print(solve(N,K,a))
test()
