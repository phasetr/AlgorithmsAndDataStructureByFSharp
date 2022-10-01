from collections import Counter

def prime_factor(n):
    ass = []
    for i in range(2,int(n**0.5)+1):
        while n % i==0:
            ass.append(i)
            n = n//i
    if n != 1:
        ass.append(n)
    return ass

def solve(n):
    primes = prime_factor(n)
    group = Counter(primes)
    phi_num = 1
    for (p,e) in group.items():
        pe_1 = p**(e-1)
        phi_num = phi_num * (p*pe_1 - pe_1)
    return phi_num

n = int(input())
print(solve(n))

print(solve(6) == 2)
print(solve(1000000) == 400000)
