# https://atcoder.jp/contests/dp/submissions/31263965
N = int(input())
H = list(map(int, input().split()))
a = list(map(int, input().split()))
H = [(H[i], i) for i in range(N)]
H.sort()

bit = [0] * (N + 1)

def get(i):
    res = 0
    i+=1
    while i > 0:
        res = max(res, bit[i])
        i -= i & -i
    return res

def add(i, x):
    i += 1
    while i < N:
        bit[i] = max(bit[i], x)
        i += i & -i

dp = [0] * (N + 1)

for h, ind in H:
    dp[ind] = a[ind]
    dp[ind] += get(ind-1)
    add(ind, dp[ind])

print(max(dp))
