# https://atcoder.jp/contests/dp/submissions/31120547
def solve(s,t):
    ls, lt = len(s), len(t)
    dp = [[0]*(lt+1) for _ in range(ls+1)]

    for i in range(1, ls+1):
        for j in range(1, lt+1):
            if s[i-1] == t[j-1]:
                dp[i][j] = dp[i-1][j-1] + 1
            else:
                dp[i][j] = max(dp[i][j-1], dp[i-1][j])

    ans = []
    i, j = ls, lt
    while i >= 1 and j >= 1:
        if s[i-1] == t[j-1]:
            ans.append(s[i-1])
            i -= 1
            j -= 1
        elif dp[i][j] == dp[i][j-1]:
            j -= 1
        elif dp[i][j] == dp[i-1][j]:
            i -= 1

    return ''.join(reversed(ans))

def main():
    s = input()
    t = input()

print(solve("axyb","abyxb") == "ayb")
