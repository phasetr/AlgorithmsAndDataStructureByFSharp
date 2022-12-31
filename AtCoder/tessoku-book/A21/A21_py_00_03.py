# https://atcoder.jp/contests/tessoku-book/submissions/36220074
n,p,a = 4,[4,3,2,1],[20,30,20,10]
def solve(n,p,a):
    d = [[0]*n for i in range(n)]
    for c in range(1,n):
        for i in range(n-c):
            l = a[i] if i<=p[i]-1<=i+c else 0
            r = a[i+c] if i<=p[i+c]-1<=i+c else 0
            d[i][i+c]=max(l+d[i+1][i+c],r+d[i][i+c-1])
    return d[0][n-1]

def main():
    n = int(input())
    p = [0]*n
    a = [0]*n
    for i in range(n):
        p[i],a[i]=map(int,input().split())
    print(solve(n,p,a))

print(solve(4,[4,3,2,1],[20,30,20,10]) == 50)
print(solve(8,[8,7,6,5,4,3,2,1],[100,100,100,100,100,100,100,100]) == 400)

# test
n = 4
for c in range(1,n):
    for i in range(n-c):
        print(i,i+c)
for i in range(0,n-1):
    for j in range(i+1,n):
        print(i,j)
for i in range(n-2,-1,-1):
    for j in range(i+1,n):
        print(i,j)
