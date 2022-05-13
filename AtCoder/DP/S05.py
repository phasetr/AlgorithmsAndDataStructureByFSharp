# https://atcoder.jp/contests/dp/submissions/31608937
def solve(k,d):
    dp = [[0] * d for i in range(len(k)+1)]
    digit_sum = 0
    for i in range(len(k)):
        for j in range(d):
            for l in range(10):
                dp[i+1][j] = (dp[i+1][j] + dp[i][(j-l)%d]) % (10**9 + 7)
        for j in range(int(k[i])):
            dp[i+1][(digit_sum+j)%d] += 1
            print(j,dp)
        digit_sum = (digit_sum + int(k[i]))%d
    dp[-1][0] -= 1
    dp[-1][digit_sum] += 1
    return (dp[-1][0] % (10**9+7))

def main():
    k = input()
    d = int(input())

#print(solve("30", 4) == 6)
print(solve("2000000014",2) == 1000000006)
