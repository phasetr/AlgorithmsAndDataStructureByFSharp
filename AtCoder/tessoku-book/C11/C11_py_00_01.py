def solve(n,k,a):
    ok,ng = 1,10**17
    while abs(ok-ng)>1:
        mid = (ok+ng)//2
        print(ok,ng,mid)
        b = sum(i*10**6//mid for i in a)
        if b>=k:
            ok = mid
        else:
            ng = mid
    print(ok)
    return [i*10**6//ok for i in a]

n,k,*a = map(int,open(0).read().split())
print(*solve(n,k,a))

def test():
    n,k,a = 4,10,[1000000,700000,300000,180000]
    print(solve(n,k,a) == [5,3,1,1])
    n,k,a = 2,3,[6000,3000]
    print(solve(n,k,a) == [2,1])
    n,k,a = 15,50,[18256245,7845995,6771945,6181431,3618432,3159625,2319156,1768385,1258501,1253872,193724,148020,109045,77861,65107]
    print(solve(n,k,a) == [18,8,7,6,3,3,2,1,1,1,0,0,0,0,0])
    n,k,a = 2,1,[900000000,100000000]
    print(solve(n,k,a) == [1,0])
