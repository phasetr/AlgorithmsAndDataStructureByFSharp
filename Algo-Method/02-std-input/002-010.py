def solve(s,n,m):
    l = list(s)
    l[n-1],l[m-1] = l[m-1],l[n-1]
    return "".join(l)
s = input()
n,m = map(int,input().split())
print(solve(s,n,m))

def test():
    print(solve("algo",2,3) == "aglo")
