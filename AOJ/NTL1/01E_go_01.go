// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_E/review/3530140/ken_/Go
package main

import (
	"fmt"
)

func extgcd(a, b int, x, y *int) int {
	if b == 0 {
		*x = 1
		*y = 0
		return a
	}
	d := extgcd(b, a%b, y, x)
	*y -= (a / b) * *x
	return d
}

func main() {
	var a, b, x, y int
	fmt.Scan(&a, &b)
	extgcd(a, b, &x, &y)
	fmt.Printf("%d %d\n", x, y)
}
