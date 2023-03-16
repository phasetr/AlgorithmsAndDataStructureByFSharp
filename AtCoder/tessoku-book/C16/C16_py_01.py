# https://atcoder.jp/contests/tessoku-book/submissions/36542475
n,m,k = map(int,input().split())
dat = [0] * m
event = []
dp = [0] * n
a = [0] * m
b = [0] * m

for i in range(m):
    a[i],s,b[i],t = map(int,input().split())
    a[i]-=1; b[i]-=1
    event.append(((s-k) << 32) + (1 << 31) + i)
    event.append((t << 32) + i)
event.sort()

mask = (1 << 31) - 1
for i in event:
    time = i >> 32
    typ = (i >> 31) & 1
    num = i & mask
    if typ == 1:
        dat[num] = dp[a[num]]
    else:
        dp[b[num]] = max(dp[b[num]], dat[num] + 1)

print(max(dp))
