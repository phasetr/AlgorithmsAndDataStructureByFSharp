// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_B/review/3618967/kshibata101/Go
package main

import (
	"fmt"
)

func main() {
	var n int
	fmt.Scan(&n)
	g := make([][]int, n+1)
	for i := 0; i < n; i++ {
		var u, k int
		fmt.Scan(&u)
		fmt.Scan(&k)
		g[u] = make([]int, k)
		for j := 0; j < k; j++ {
			fmt.Scan(&g[u][j])
		}
	}

	d := make([]int, n+1)
	f := make([]int, n+1)
	t := 1
	for i := 1; i <= n; i++ {
		t = dfs(&g, &d, &f, i, t)
	}

	for i := 1; i <= n; i++ {
		fmt.Printf("%d %d %d\n", i, d[i], f[i])
	}
}

func dfs(g *[][]int, d *[]int, f *[]int, id int, t int) int {
	if (*d)[id] > 0 {
		return t
	}
	(*d)[id] = t
	t += 1
	for i := 0; i < len((*g)[id]); i++ {
		t = dfs(g, d, f, (*g)[id][i], t)
	}
	(*f)[id] = t
	return t + 1
}
