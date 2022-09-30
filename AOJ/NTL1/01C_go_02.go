// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_C/review/3233840/elf48/Go
package main

import (
	"fmt"
)

func gcd(a, b int) int {
	r := 0
	for true {
		r = a % b
		a = b
		b = r
		if r == 0 {
			break
		}
	}
	return a
}

func lcm(a, b int) int {
	L := 0
	G := gcd(a, b)
	L = a / G * b
	return L
}
func main() {
	var N, Input int
	anslcm := 1
	fmt.Scanf("%d", &N)
	for i := 0; i < N; i++ {
		fmt.Scanf("%d", &Input)
		anslcm = lcm(anslcm, Input)
	}
	fmt.Printf("%d\n", anslcm)
}
