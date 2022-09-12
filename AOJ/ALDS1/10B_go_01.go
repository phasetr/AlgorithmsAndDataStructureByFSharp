// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_B/review/5306134/kshibata101/Go
package main

import "fmt"

func main() {
	var n int
	fmt.Scan(&n)

	M := make([]int, n+1)
	dp := make([][]int, n+1)
	for i := 0; i < n; i++ {
		fmt.Scan(&M[i])
		fmt.Scan(&M[i+1])
		dp[i] = make([]int, n+1)
	}

	for d := 2; d <= n; d++ {
		for l := 0; l+d <= n; l++ {
			r := l + d
			dp[l][r] = 1 << 30
			for k := l + 1; k < r; k++ {
				cal := dp[l][k] + dp[k][r] + M[l]*M[k]*M[r]
				if cal < dp[l][r] {
					dp[l][r] = cal
				}
			}
		}
	}
	fmt.Println(dp[0][n])
}
