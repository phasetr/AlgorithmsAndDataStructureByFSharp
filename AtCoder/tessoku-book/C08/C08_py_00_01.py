# https://atcoder.jp/contests/tessoku-book/submissions/34888695
def f(X,Y):
    c = sum(x != y for x,y in zip(X,Y))
    return min(c+1,3)

def solve(n,L):
     Z = []
     for i in range(10**4):
         x = f"{i:04}"
         if all(f(s,x) == t for s,t in L):
             Z.append(x)
     return Z[0] if len(Z) == 1 else "Can't Solve"

n = int(input())
L = []
for _ in range(n):
    s,t = input().split()
    L.append((s,int(t)))

def test():
    n,L = 3,[("2649",2),("4749",2),("2749",3)]
    print(solve(n,L) == "4649")
    n,L = 2,[("1234",3),("8894",2)]
    print(solve(n,L) == "Can't Solve")
    n,L = 2,[("1234",3),("8894",1)]
    print(solve(n,L) == "8894")
