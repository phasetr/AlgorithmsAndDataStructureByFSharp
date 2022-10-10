// https://onlinejudge.u-aizu.ac.jp/solutions/problem/DSL_1_A/review/4809042/naoya0x00/Go
package main

import "fmt"

func main() {
	var n, q, com, x, y int
	fmt.Scan(&n, &q)
	p := make([]int, n)
	for i := range p {
		p[i] = i
	}
	for i := 0; i < q; i++ {
		fmt.Scan(&com, &x, &y)
		var b, l int
		if com == 1 {
			if p[x] == p[y] {
				fmt.Println(1)
			} else {
				fmt.Println(0)
			}
		} else {
			if p[x] > p[y] {
				b = p[x]
				l = p[y]
			} else {
				b = p[y]
				l = p[x]
			}
			for j, v := range p {
				if v == b {
					p[j] = l
				}
			}
		}
	}
}
