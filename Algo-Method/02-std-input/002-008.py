def solve(s,t,u): return u+t+s
s = input()
t = input()
u = input()
print(solve(s,t,u))

def test():
    print(solve("hod","met","algo") == "algomethod")
