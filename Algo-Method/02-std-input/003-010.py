def solve(n,S):
    l,r = 0,0
    for s in S:
        if s=="left": l=l+1
        else: r=r+1
    return "left" if r<l else "right" if l<r else "same"
n = int(input())
S = [input() for i in range(n)]
print(solve(n,S))

def test():
    n,S = 3,["left","left","right"]
    print(solve(n,S) == "left")
    n,S = 3,["left","right","right"]
    print(solve(n,S) == "right")
    n,S = 4,["left","left","right","right"]
    print(solve(n,S) == "same")
