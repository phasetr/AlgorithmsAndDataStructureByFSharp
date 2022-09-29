# メモリが制限を越える
import sys
sys.setrecursionlimit(20000)
def solve(n):
    def frec(i,x,acc):
        if i*i>n:
            return acc if x==1 else acc+[x]
        elif x%i == 0:
            return frec(i, x//i, acc+[i])
        else:
            return frec(i+1,x,acc)
    return frec(2,n,[])

n = int(input())
xs = " ".join(map(lambda x: str(x),solve(n)))
print(f"{n}: {xs}")

print(solve(12) == [2,2,3])
print(solve(126) == ([2,3,3,7]))
