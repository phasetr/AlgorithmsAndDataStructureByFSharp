# https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_D/review/6060836/rin204/Python3
n = int(input())
N = n
ans = []
for i in range(2, int(n ** 0.5 + 1)):
    if n % i == 0:
        N //= i
        N *= i - 1
        while n % i == 0:
            ans.append(i)
            n //= i
if n != 1:
    N //= n
    N *= n - 1
print(N)
