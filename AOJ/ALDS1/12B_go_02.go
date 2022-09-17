// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_B/review/4098941/inabajunmr/Go
package main

import (
	"bufio"
	"fmt"
	"math"
	"os"
	"strconv"
)

const MAX = 100
const INFTY = math.MaxInt64
const WHITE = 0
const GRAY = 1
const BLACK = 2

var n int
var M [MAX][MAX]int

func dijkstra() {
	var minv int
	var d [MAX]int
	var color [MAX]int

	for i := 0; i < n; i++ {
		d[i] = INFTY
		color[i] = WHITE
	}

	d[0] = 0
	color[0] = GRAY
	for {

		minv = INFTY
		u := -1
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
			if color[v] != BLACK && M[u][v] != INFTY {
				if d[v] > d[u]+M[u][v] {
					d[v] = d[u] + M[u][v]
					color[v] = GRAY
				}
			}
		}

	}
	for i := 0; i < n; i++ {
		fmt.Printf("%v %v\n", i, d[i])
	}
}

func main() {
	sc := bufio.NewScanner(os.Stdin)
	sc.Split(bufio.ScanWords)
	sc.Scan()
	n, _ = strconv.Atoi(sc.Text())

	for i := 0; i < n; i++ {
		for j := 0; j < n; j++ {
			M[i][j] = INFTY
		}
	}

	for i := 0; i < n; i++ {
		sc.Scan()
		f, _ := strconv.Atoi(sc.Text())
		sc.Scan()
		k, _ := strconv.Atoi(sc.Text())
		for j := 0; j < k; j++ {
			sc.Scan()
			v, _ := strconv.Atoi(sc.Text())
			sc.Scan()
			c, _ := strconv.Atoi(sc.Text())
			M[f][v] = c
		}
	}
	dijkstra()
}
