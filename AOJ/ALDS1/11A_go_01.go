// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_A/review/3618920/kshibata101/Go
package main

import (
	"fmt"
)

func main() {
	var n int
	fmt.Scan(&n)
	g := make([][]int, n)
	for i := 0; i < n; i++ {
		g[i] = make([]int, n)
	}

	for i := 0; i < n; i++ {
		var u, k int
		fmt.Scan(&u)
		fmt.Scan(&k)
		for j := 0; j < k; j++ {
			var v int
			fmt.Scan(&v)
			g[u-1][v-1] = 1
		}
	}

	for i := 0; i < n; i++ {
		fmt.Print(g[i][0])
		for j := 1; j < n; j++ {
			fmt.Printf(" %d", g[i][j])
		}
		fmt.Println()
	}
}
