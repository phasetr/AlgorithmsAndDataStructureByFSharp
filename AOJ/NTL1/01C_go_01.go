// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_C/review/3530365/ken_/Go
package main

import (
	"fmt"
)

func gcd(a, b int) int {
	if b == 0 {
		return a
	}
	return gcd(b, a%b)
}

func main() {
	var n int
	fmt.Scan(&n)
	lcm := 1
	var a int
	for i := 0; i < n; i++ {
		fmt.Scan(&a)
		lcm = lcm * a / gcd(lcm, a)
	}
	fmt.Println(lcm)
}
