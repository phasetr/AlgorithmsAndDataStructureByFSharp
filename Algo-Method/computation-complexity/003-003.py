def solve(n,m):
    count = 0
    for x in range(1,n+1):
        for y in range(1,n+1):
            s = m-x-y
            if x+y < m:
                count += n if n<=s else s
    return count
n,m = list(map(int,input().split()))
print(solve(n,m))

def test():
    n,m = 2,4
    print(solve(n,m) == 4)
    n,m = 1000,2022
    print(solve(n,m) == 843614540)
