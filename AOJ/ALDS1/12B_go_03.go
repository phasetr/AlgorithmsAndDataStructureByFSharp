// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_B/review/3067517/s1250034/Go
package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

var sc = bufio.NewScanner(os.Stdin)

const T = 10000000

var n int
var A [101][101]int

func nextInt() int {
	sc.Scan()
	i, _ := strconv.Atoi(sc.Text())
	return i
}
func Shortestsearch() {
	var Minimum int
	var d, color [100]int
	var u int

	for i := 0; i < n; i++ {
		d[i] = T
		color[i] = 0
	}

	d[0] = 0
	color[0] = 1

	for {
		Minimum = T
		u = -1
		for i := 0; i < n; i++ {
			if Minimum > d[i] && color[i] != 2 {
				u = i
				Minimum = d[i]
			}
		}
		if u == -1 {
			break
		}
		color[u] = 2
		for j := 0; j < n; j++ {
			if color[j] != 2 && A[u][j] != T {
				if d[j] > d[u]+A[u][j] {
					d[j] = d[u] + A[u][j]
					color[j] = 1
				}
			}
		}
	}
	for i := 0; i < n; i++ {
		fmt.Printf("%d %d\n", i, d[i])
	}
}
func main() {
	sc.Split(bufio.ScanWords)
	n = nextInt()

	for i := 0; i < n; i++ {
		for j := 0; j < n; j++ {
			A[i][j] = T
		}
	}
	for i := 0; i < n; i++ {
		u := nextInt()
		k := nextInt()
		for j := 0; j < k; j++ {
			v := nextInt()
			c := nextInt()
			A[u][v] = c
		}
	}
	Shortestsearch()
}
