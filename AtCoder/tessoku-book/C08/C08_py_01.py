# https://atcoder.jp/contests/tessoku-book/submissions/34888695
def f(X,Y):
    c = sum(x != y for x,y in zip(X,Y))
    return min(c+1,3)
n = int(input())
L = []
for _ in range(n):
    s,t = input().split()
    L.append((s,int(t)))
Z = []
for i in range(10**4):
    x = f"{i:04}"
    if all(f(s,x) == t for s,t in L):
        Z.append(x)
if len(Z) == 1: print(Z[0])
else: print("Can't Solve")
