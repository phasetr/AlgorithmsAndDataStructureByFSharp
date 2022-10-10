// https://onlinejudge.u-aizu.ac.jp/solutions/problem/DSL_1_A/review/4392134/zaki_joho/Go
package main

import "fmt"

type UnionFind struct {
	Data []int
}

func (uf *UnionFind) Root(x int) int {
	if uf.Data[x] < 0 {
		return x
	}
	uf.Data[x] = uf.Root(uf.Data[x])
	return uf.Data[x]
}

func (uf *UnionFind) Unite(x, y int) bool {
	rx := uf.Root(x)
	ry := uf.Root(y)
	if rx != ry {
		if uf.Data[rx] < uf.Data[ry] {
			uf.Data[rx], uf.Data[ry] = uf.Data[ry], uf.Data[rx]
		}
		uf.Data[rx] += uf.Data[ry]
		uf.Data[ry] = rx
	}
	return rx != ry
}

func (uf *UnionFind) Same(x, y int) bool {
	return uf.Root(x) == uf.Root(y)
}

func main() {
	var n, q int
	fmt.Scanf("%d %d", &n, &q)

	var uf UnionFind
	uf.Data = make([]int, n)
	for i := 0; i < n; i++ {
		uf.Data[i] = -1
	}

	for i := 0; i < q; i++ {
		var com, x, y int
		fmt.Scanf("%d %d %d", &com, &x, &y)
		if com == 0 {
			// unite
			uf.Unite(x, y)
			continue
		}
		if uf.Same(x, y) {
			fmt.Println(1)
		} else {
			fmt.Println(0)
		}
	}
}
