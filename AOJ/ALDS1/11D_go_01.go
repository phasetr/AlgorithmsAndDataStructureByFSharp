// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_D/review/4087578/inabajunmr/Go
package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

var (
	n     int
	G     [100000][]int
	color [100000]*int
)

func dfs(r int, c int) {
	S := Stack{}
	S.Push(r)
	color[r] = &c
	for !S.IsEmpty() {
		u := S.Pop()
		for i := 0; i < len(G[u]); i++ {
			v := G[u][i]
			if color[v] == nil {
				color[v] = &c
				S.Push(v)
			}
		}
	}
}

func assignColor() {
	id := 1
	for i := 0; i < n; i++ {
		color[i] = nil
	}
	for u := 0; u < n; u++ {
		if color[u] == nil {
			id++
			dfs(u, id)
		}
	}
}

func main() {
	sc := bufio.NewScanner(os.Stdin)
	sc.Split(bufio.ScanWords)
	sc.Scan()
	n, _ = strconv.Atoi(sc.Text())
	sc.Scan()
	r, _ := strconv.Atoi(sc.Text())

	for i := 0; i < r; i++ {
		sc.Scan()
		s, _ := strconv.Atoi(sc.Text())
		sc.Scan()
		t, _ := strconv.Atoi(sc.Text())
		G[s] = append(G[s], t)
		G[t] = append(G[t], s)
	}
	assignColor()
	sc.Scan()
	qNum, _ := strconv.Atoi(sc.Text())
	for i := 0; i < qNum; i++ {
		sc.Scan()
		s, _ := strconv.Atoi(sc.Text())
		sc.Scan()
		t, _ := strconv.Atoi(sc.Text())
		if color[s] == color[t] {
			fmt.Println("yes")
		} else {
			fmt.Println("no")
		}
	}
}

// Stack is Stack
type Stack struct {
	stack []int
}

// Push new value
func (stack *Stack) Push(val int) {
	stack.stack = append(stack.stack, val)
}

// Pop new value
func (stack *Stack) Pop() int {
	val := stack.stack[len(stack.stack)-1]
	stack.stack = stack.stack[0 : len(stack.stack)-1]
	return val
}

// IsEmpty return true when stack is empty
func (stack *Stack) IsEmpty() bool {
	return len(stack.stack) == 0
}
