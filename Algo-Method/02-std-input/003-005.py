def solve(n,A): return list(reversed(A))
n = input()
A = list(map(int,input().split()))
for x in solve(n,A): print(x)

def test():
    n,A = 3,[31,41,59]
    print(solve(n,A) == [59,41,31])
