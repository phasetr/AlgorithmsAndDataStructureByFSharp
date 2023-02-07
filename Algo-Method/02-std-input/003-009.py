def solve(n,S): return "".join(list(map(lambda x:x[0], S)))
n = int(input())
S = [input() for x in range(n)]
print(solve(n,S))

def test():
    n,S = 4,["hyper","text","transfer","protocol"]
    print(solve(n,S) == "http")
