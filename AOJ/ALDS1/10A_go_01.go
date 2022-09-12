// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_A/review/3649309/magusofrage/Go
package main

import (
	"fmt"
)

func main() {
	var n int
	fmt.Scan(&n)

	fibo := make([]int, n+1)
	fibo[0] = 1
	fibo[1] = 1

	for i := 2; i <= n; i++ {
		fibo[i] = fibo[i-1] + fibo[i-2]
	}

	fmt.Println(fibo[n])
}
