# https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_C/review/2163086/cima/Python3
def gcd(a,b):
    while b:a,b=b,a%b
    return a

def lcm(a,b):
    return a//gcd(a,b)*b

input()
a = list(map(int,input().split()))
b = 1
for i in a:
    b = lcm(b,i)
print(b)
