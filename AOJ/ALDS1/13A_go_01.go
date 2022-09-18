// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_A/review/3638968/kshibata101/Go
package main

import (
	"fmt"
)

func main() {
	var k int
	fmt.Scan(&k)
	m := make([]int, 8)
	for i := 0; i < 8; i++ {
		m[i] = -1
	}

	for i := 0; i < k; i++ {
		var r int
		fmt.Scan(&r)
		fmt.Scan(&m[r])
	}

	search(0, &m)

	for r := 0; r < 8; r++ {
		for c := 0; c < 8; c++ {
			if m[r] == c {
				fmt.Print("Q")
			} else {
				fmt.Print(".")
			}
		}
		fmt.Println()
	}
}

func search(r int, m *[]int) bool {
	if r >= 8 {
		return true
	}
	if (*m)[r] >= 0 {
		return search(r+1, m)
	}
	for c := 0; c < 8; c++ {
		if check(r, c, m) == false {
			continue
		}

		(*m)[r] = c
		if search(r+1, m) {
			return true
		} else {
			(*m)[r] = -1
		}
	}
	return false
}

func check(r int, c int, m *[]int) bool {
	for i := 0; i < 8; i++ {
		if (*m)[i] == -1 {
			continue
		}
		if c == (*m)[i] {
			return false
		}
		if (r - c) == (i - (*m)[i]) {
			return false
		}
		if (r + c) == (i + (*m)[i]) {
			return false
		}
	}
	return true
}
