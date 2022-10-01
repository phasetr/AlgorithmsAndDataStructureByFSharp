// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_D/review/3943846/risktaker/Go
package main

import "fmt"

func main() {
	var n int
	fmt.Scan(&n)
	fmt.Println(euler_phi(n))
}

func euler_phi(n int) int {
	r := n
	for i := 2; i*i <= n; i++ {
		if n%i == 0 {
			r = r / i * (i - 1)
			for ; n%i == 0; n /= i {
			}
		}
	}
	if n != 1 {
		r = r / n * (n - 1)
	}
	return r
}
