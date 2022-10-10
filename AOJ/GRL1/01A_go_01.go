// https://onlinejudge.u-aizu.ac.jp/solutions/problem/GRL_1_A/review/4606094/tsbkw0/Go
package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

func newScanner() *bufio.Scanner {
	scanner := bufio.NewScanner(os.Stdin)
	scanner.Split(bufio.ScanWords)
	return scanner
}

var sc = newScanner()

func scanInt() int {
	sc.Scan()
	v, _ := strconv.Atoi(sc.Text())
	return v
}

func scanInts(n int) []int {
	a := make([]int, n)
	for i := 0; i < n; i++ {
		a[i] = scanInt()
	}
	return a
}

func scanString() string {
	if sc.Scan() {
		return sc.Text()
	}
	panic(sc.Err())
}

func main() {
	v, e, r := scanInt(), scanInt(), scanInt()
	edgeMap := make(map[int][]edge)
	for i := 0; i < e; i++ {
		ed := edge{scanInt(), scanInt(), scanInt()}
		if _, exists := edgeMap[ed.from]; !exists {
			edgeMap[ed.from] = []edge{}
		}
		edgeMap[ed.from] = append(edgeMap[ed.from], ed)
	}

	printSingleSourceShortestPath(v, r, edgeMap)
}

type edge struct {
	from, to, cost int
}

func debug(a ...interface{}) {
	// fmt.Println(a...)
}

const inf = 10000000000000

func printSingleSourceShortestPath(v, r int, edgeMap map[int][]edge) {
	d := make([]int, v)
	for i := 0; i < v; i++ {
		if i != r {
			d[i] = inf
		}
	}
	queue := []int{r}
	for len(queue) != 0 {
		nextQueue := []int{}
		for _, node := range queue {
			for _, e := range edgeMap[node] {
				debug(node, d[e.to], d[node], e.cost)
				if d[e.to] > d[node]+e.cost {
					d[e.to] = d[node] + e.cost
					nextQueue = append(nextQueue, e.to)
				}
			}
		}
		debug("nextQueue", nextQueue)
		queue = nextQueue
	}
	for i := 0; i < v; i++ {
		if d[i] != inf {
			fmt.Println(d[i])
		} else {
			fmt.Println("INF")
		}

	}
}
