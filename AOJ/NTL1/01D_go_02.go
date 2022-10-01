// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_D/review/3530973/ken_/Go
package main

import (
	"fmt"
)

func eulerPhi(n int) int {
	res := n
	for i := 2; i*i <= n; i++ {
		if n%i == 0 {
			res = res / i * (i - 1)
			for ; n%i == 0; n /= i {
			}
		}
	}
	if n != 1 {
		res = res / n * (n - 1)
	}
	return res
}

func main() {
	n := 0
	fmt.Scan(&n)
	fmt.Println(eulerPhi(n))
}
