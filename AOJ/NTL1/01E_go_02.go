// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_E/review/3945735/risktaker/Go
package main

import "fmt"

func main() {
	var a, b int
	fmt.Scan(&a, &b)
	_, x, y := extgcd(a, b)
	fmt.Printf("%d %d\n", x, y)
}

func extgcd(a, b int) (d, x, y int) {
	if b == 0 {
		x = 1
		y = 0
		return a, x, y
	} else {

	}

	d, y, x = extgcd(b, a%b)
	y -= (a / b) * x
	return d, x, y
}
