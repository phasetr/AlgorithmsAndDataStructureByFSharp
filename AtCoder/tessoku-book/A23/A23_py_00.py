def solve(n,m,a):
    inf = float('inf')
    dp = [inf]*(1<<n)
    dp[0] = 0
    for i in range(m):
        for bit in range(1<<n):
            dp[bit|a[i]] = min(dp[bit|a[i]], dp[bit]+1)
    return (-1 if dp[-1] == inf else dp[-1])

def main():
    n,m = map(int,input().split())
    a = [int("".join(input().split()), 2) for _ in range(M)]
    print(solve(n, m, a))

def to_bin(aa):
    b = []
    for a in aa:
        b.append(int("".join(map(lambda i: str(i), a)), 2))
    return b

def test():
    print(int("".join("0 0 1".split()), 2))
    # `a`は二進数に変換
    n,m,a = 3,4,to_bin([[0,0,1],[0,1,0],[1,0,0],[1,1,0]])
    print(solve(n, m, a) == 2)
    n,m,a = 10,2,to_bin([[1,1,1,1,0,0,0,0,0,0],[0,0,0,0,1,1,1,1,0,0]])
    print(solve(n,m,a) == -1)
