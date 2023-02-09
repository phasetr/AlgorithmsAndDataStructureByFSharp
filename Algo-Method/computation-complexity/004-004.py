def solve(n,d,X):
    s = [0]
    for x in X: s.append(s[-1]+x)
    k,m = 0,0
    for i in range(n-d+1):
        m0 = s[i+d]-s[i]
        if m<=m0: k=i; m=m0
    return f"{k}~{k+d-1}"
n,d = list(map(int,input().split()))
X = list(map(int,input().split()))
print(solve(n,d,X))

def test():
    n,d,X = 6,3,[100,200,320,400,200,140]
    print(solve(n,d,X))
    print(solve(n,d,X) == "2~4")
