// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_C/review/3618997/kshibata101/Go
package main

import (
	"fmt"
)

func main() {
	var n int
	fmt.Scan(&n)

	g := make([][]int, n+1)
	d := make([]int, n+1)
	for i := 0; i < n; i++ {
		var u, k int
		fmt.Scan(&u)
		fmt.Scan(&k)
		g[u] = make([]int, k)
		for j := 0; j < k; j++ {
			fmt.Scan(&g[u][j])
		}

		d[i+1] = -1
	}

	q := [][]int{}
	q = append(q, []int{1, 0})
	for len(q) > 0 {
		pop := q[0]
		if len(q) > 1 {
			q = q[1:]
		} else {
			q = [][]int{}
		}
		if d[pop[0]] >= 0 {
			continue
		}
		d[pop[0]] = pop[1]

		for j := 0; j < len(g[pop[0]]); j++ {
			q = append(q, []int{g[pop[0]][j], pop[1] + 1})
		}
	}

	for i := 1; i <= n; i++ {
		fmt.Printf("%d %d\n", i, d[i])
	}
}
