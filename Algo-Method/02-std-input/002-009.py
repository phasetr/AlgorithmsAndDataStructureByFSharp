def solve(s,n): return s[n-1]
s = input()
n = int(input())
print(solve(s,n))

def test():
    print(solve("algo", 2) == "l")
