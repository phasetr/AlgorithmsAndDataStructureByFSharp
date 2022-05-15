# https://atcoder.jp/contests/dp/submissions/31419910
N = int(input())
A = [list(map(int,input().split())) for _ in range(N)]

dp = [0] *(2**N)
for i in range(2**N):
    L = [0]*N
    for j in range(N):
        if (i>>j)&1:
            L[j] = 1
    #print(L)
    for x in range(N-1):
        for y in range(x+1,N):
            if L[x]&L[y]:
                dp[i] += A[x][y]
#print(dp)

for bit in range(2**N):
    part = (bit-1)&bit
    #print(bit,bit-1,bin(bit)[2:],bin(bit-1)[2:],part)
    while part:
        #print(bit,part,bit^part)
        dp[bit] = max(dp[bit],dp[part]+dp[bit^part])
        part = (part-1)&bit
#print(dp)
print(dp[-1])
