# https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_A/review/5808884/vjudge2/Python3
n = int(input())

f_n = n
l = []

if n == 1:
    l.append(1)
    exit()

# 試し割り法
for i in range(2,int(n**0.5)+1):
    while n % i == 0:
        n //= i
        l.append(i)
if n != 1:
    l.append(n)

print("{0}:".format(f_n),*l)
