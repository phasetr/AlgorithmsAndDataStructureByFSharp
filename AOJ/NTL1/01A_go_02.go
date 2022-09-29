// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_A/review/3943709/risktaker/Go
package main

import "fmt"

func main() {
	var n int
	fmt.Scan(&n)
	fmt.Printf("%d:", n)
	for i := 2; i*i <= n; i++ {
		for n%i == 0 {
			fmt.Printf(" %d", i)
			n /= i
		}
	}
	if n > 1 {
		fmt.Printf(" %d", n)
	}
	fmt.Println("")
}
