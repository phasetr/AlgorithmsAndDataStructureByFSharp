# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_A/review/3294710/haji149/Python3
n = int(input())
A = [int(i) for i in input().split()]

q = int(input())
m = [int(i) for i in input().split()]

def dfs(idx, s, target):
    if s == target:
        return 1

    if s > target or idx == n:
        return 0
    if s + sum(A[idx:]) < target:
        return 0

    return dfs(idx+1, s, target) or dfs(idx+1, s + A[idx], target)

for target in m:
    ans = 'yes' if dfs(0, 0, target) else 'no'
    print(ans)
