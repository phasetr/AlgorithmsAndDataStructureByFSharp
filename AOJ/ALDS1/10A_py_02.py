# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_A/review/5906539/lloyz_nt/Python3
n = int(input())

fib = [0 for _ in range(n + 1)]
fib[0] = fib[1] = 1
for i in range(2, n + 1):
    fib[i] = fib[i - 1] + fib[i - 2]
print(fib[n])
