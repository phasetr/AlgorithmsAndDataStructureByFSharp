#!/usr/bin/env python3
def solve(n,a,b):
    su = [-99999999] * (n + 1)
    su[1] = 0
    for i in range(1,n):
        su[a[i - 1]] = max(su[a[i - 1]],su[i] + 100)
        su[b[i - 1]] = max(su[b[i - 1]],su[i] + 150)
    return su[n]

def main():
    n = int(input())
    a = list(map(int,input().split()))
    b = list(map(int,input().split()))
    print(solve(n,a,b))

main()

def test():
    n,a,b = 7,[2,4,4,7,6,7],[3,5,6,7,7,7]
    print(solve(n,a,b) == 500)
