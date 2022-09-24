// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_C/review/3581058/m5231136/Go
package main

import (
	"bufio"
	"fmt"
	"math"
	"os"
)

var dy = []int{-1, 0, 1, 0}
var dx = []int{0, 1, 0, -1}
var limit = 0
var N = 4
var t = make([][]int, N)

func main() {
	var in = bufio.NewReader(os.Stdin)
	for i := 0; i < N; i++ {
		t[i] = make([]int, N)
	}
	var py, px int
	for i := 0; i < N; i++ {
		fmt.Fscanf(in, "%d %d %d %d\n", &t[i][0], &t[i][1], &t[i][2], &t[i][3])
	}
	for i := 0; i < N; i++ {
		for j := 0; j < N; j++ {
			if t[i][j] == 0 {
				py = i
				px = j
			}
		}
	}

	Solve(py, px)
}

func getH() int {
	sum, x, i, j := 0, 0, 0, 0
	for i = 0; i < N; i++ {
		for j = 0; j < N; j++ {
			if t[i][j] == 0 {
				continue
			}
			x = t[i][j] - 1
			sum += int(math.Abs(float64(int(x/N)-i)) + math.Abs(float64(int(x%N)-j)))
		}
	}
	return sum
}

func dfs(depth int, prev int, py int, px int) bool {
	h := getH()
	if h+depth > limit {
		return false
	}
	if h == 0 {
		return true
	}
	for i := 0; i < N; i++ {
		if int(math.Abs(float64(i-prev))) == 2 {
			continue
		}
		ty, tx := py+dy[i], px+dx[i]
		if ty < 0 || tx < 0 || ty >= N || tx >= N {
			continue
		}
		t[ty][tx], t[py][px] = t[py][px], t[ty][tx]
		if dfs(depth+1, i, ty, tx) {
			return true
		}
		t[ty][tx], t[py][px] = t[py][px], t[ty][tx]
	}
	return false
}

func Solve(py int, px int) {
	for limit = 0; ; limit++ {
		if dfs(0, 99, py, px) {
			fmt.Println(limit)
			return
		}
	}
}
