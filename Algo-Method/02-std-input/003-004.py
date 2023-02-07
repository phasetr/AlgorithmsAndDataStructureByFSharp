def solve(n,A): return list(filter(lambda x: x%3==0, A))
n = input()
A = map(int,input().split())
for x in solve(n,A): print(x)

def test():
    n,A = 3,[27,18,28]
    print(solve(n,A) == [27,18])
    n,A = 3,[31,41,59]
    print(solve(n,A) == [])
