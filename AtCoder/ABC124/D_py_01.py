# https://atcoder.jp/contests/abc124/submissions/4981941

n,k,s = 5,1,"00010"
n,k,s = 14,2,"11101010110011"
def solve(n,k,s):
    l = [0]
    for i in range(n-1):
        if s[i] != s[i+1]:
            l.append(i+1)

    l.append(n)
    ans = 0
    for i in range(len(l)-1):
        index = min(i+2*k + int(s[l[i]]=="1"), len(l)-1)
        ans = max(ans, l[index] - l[i])

    return ans

def main():
    n,k = map(int,input().split())
    s = input()
    print(solve(n,k,s))

print(solve(5,1,"00010") == 4)
print(solve(14,2,"11101010110011") == 8)
print(solve(1,1,"1") == 1)
