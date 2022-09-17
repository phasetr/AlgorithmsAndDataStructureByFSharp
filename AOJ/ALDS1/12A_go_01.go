// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_A/review/4087793/inabajunmr/Go
package main

import (
	"bufio"
	"fmt"
	"math"
	"os"
	"strconv"
)

var (
	n int
	M [MAX][MAX]int
)

const MAX = 100
const WHITE = 0
const GRAY = 1
const BLACK = 2

func main() {
	sc := bufio.NewScanner(os.Stdin)
	sc.Split(bufio.ScanWords)
	sc.Scan()
	n, _ = strconv.Atoi(sc.Text())

	for i := 0; i < n; i++ {
		for j := 0; j < n; j++ {
			sc.Scan()
			c, _ := strconv.Atoi(sc.Text())
			if c != -1 {
				M[i][j] = c
			} else {
				M[i][j] = math.MaxInt64
			}

		}
	}
	prim()
}

func prim() {
	var u int
	var minv int
	var d [MAX]int
	var p [MAX]int
	var color [MAX]int

	for i := 0; i < n; i++ {
		d[i] = math.MaxInt64
		p[i] = -1
		color[i] = WHITE
	}

	d[0] = 0

	for {
		minv = math.MaxInt64
		u = -1
		for i := 0; i < n; i++ {
			if minv > d[i] && color[i] != BLACK {
				u = i
				minv = d[i]
			}
		}

		if u == -1 {
			break
		}

		color[u] = BLACK

		for v := 0; v < n; v++ {
			if color[v] != BLACK && M[u][v] != math.MaxInt64 {
				if d[v] > M[u][v] {
					d[v] = M[u][v]
					p[v] = u
					color[v] = GRAY
				}
			}
		}
	}
	sum := 0
	for i := 0; i < n; i++ {
		if p[i] != -1 {
			sum += M[i][p[i]]
		}
	}
	fmt.Println(sum)

}
