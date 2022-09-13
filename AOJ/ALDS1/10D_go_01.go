// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_D/review/3618612/kshibata101/Go
package main

import (
	"fmt"
	"math"
)

func main() {
	var n int
	fmt.Scan(&n)

	p := make([]float64, n+1)
	q := make([]float64, n+1)
	psum := make([]float64, n+2) // i番目はi-1までの和とする
	qsum := make([]float64, n+2) // i番目はi-1までの和とする
	for i := 1; i <= n; i++ {
		fmt.Scan(&p[i])
		psum[i+1] = psum[i] + p[i]
	}
	for i := 0; i <= n; i++ {
		fmt.Scan(&q[i])
		qsum[i+1] = qsum[i] + q[i]
	}

	dp := make([][]float64, n+1)
	for i := 0; i <= n; i++ {
		dp[i] = make([]float64, n+1)
	}

	// calc
	for d := 0; d <= n; d++ {
		for l := 0; l+d <= n; l++ {
			r := l+d
			if l == r {
				dp[l][r] = q[l]
				continue
			}

			dp[l][r] = 1 << 30
			// iは中心となるnode
			for i := l+1; i <= r; i++ {
				left := dp[l][i-1] + psum[i] - psum[l+1] + qsum[i] - qsum[l]
				right := dp[i][r] + psum[r+1] - psum[i+1] + qsum[r+1] - qsum[i]
				dp[l][r] = math.Min(dp[l][r], p[i] + left + right)
			}
		}
	}

	fmt.Printf("%.8f\n", dp[0][n])
}
