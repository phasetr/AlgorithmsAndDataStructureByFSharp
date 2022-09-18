// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_C/review/3638591/kshibata101/Go
package main

import (
	"bufio"
	"container/heap"
	"fmt"
	"os"
	"strconv"
)

type Node struct {
	Id  int
	Dis int
}

type PriorityQueue []*Node

func (pq PriorityQueue) Len() int { return len(pq) }

func (pq PriorityQueue) Less(i, j int) bool {
	return pq[i].Dis < pq[j].Dis
}

func (pq PriorityQueue) Swap(i, j int) {
	pq[i], pq[j] = pq[j], pq[i]
}

func (pq *PriorityQueue) Push(x interface{}) {
	*pq = append(*pq, x.(*Node))
}

func (pq *PriorityQueue) Pop() interface{} {
	n := len(*pq)
	pop := (*pq)[n-1]
	*pq = (*pq)[0 : n-1]
	return pop
}

func main() {
	var n int
	fmt.Scan(&n)

	sc := bufio.NewScanner(os.Stdin)
	sc.Split(bufio.ScanWords)

	g := make([][]int, n)
	c := make([][]int, n)
	pq := make(PriorityQueue, 0, n)
	d := make([]int, n)
	for i := 0; i < n; i++ {
		sc.Scan()
		u, _ := strconv.Atoi(sc.Text())
		sc.Scan()
		k, _ := strconv.Atoi(sc.Text())
		g[u] = make([]int, k)
		c[u] = make([]int, k)
		for j := 0; j < k; j++ {
			sc.Scan()
			g[u][j], _ = strconv.Atoi(sc.Text())
			sc.Scan()
			c[u][j], _ = strconv.Atoi(sc.Text())
		}

		if u == 0 {
			d[u] = 0
		} else {
			d[u] = 1 << 30
		}
		pq.Push(&Node{u, d[u]})
	}
	heap.Init(&pq)

	for pq.Len() > 0 {
		node := heap.Pop(&pq).(*Node)
		for i := 0; i < len(g[node.Id]); i++ {
			nextId := g[node.Id][i]
			nextDis := node.Dis + c[node.Id][i]
			if nextDis < d[nextId] {
				d[nextId] = nextDis
				heap.Push(&pq, &Node{nextId, nextDis})
			}
		}
	}

	wr := bufio.NewWriter(os.Stdout)
	for i := 0; i < n; i++ {
		wr.WriteString(strconv.Itoa(i))
		wr.WriteString(" ")
		wr.WriteString(strconv.Itoa(d[i]))
		wr.WriteString("\n")
	}
	wr.Flush()
}
