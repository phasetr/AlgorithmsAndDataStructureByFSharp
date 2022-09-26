import sys
sys.setrecursionlimit(30000)
def solve(T,P):
    l1 = len(T)
    l2 = len(P)
    def loop(i,r):
        if l1-l2<i:
            return r
        else:
            s = T[i:i+l2]
            rnew = r
            if s == P:
                rnew.append(i)
            return loop(i+1,rnew)
    return loop(0,[])

T = input()
P = input()
l = solve(T,P)
if len(l) != 0:
    for i in l:
        print(i)

print(solve("aabaaa","aa") == [0,3,4])
print(solve("xyzz","yz") == [1])
print(solve("abc","xyz") == [])
