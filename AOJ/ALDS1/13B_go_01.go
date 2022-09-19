// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_B/review/3072240/s1250034/Go
package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

var sc = bufio.NewScanner(os.Stdin)

func search(in [9]byte) int {
	for i := 0; i < 9; i++ {
		if in[i] == byte(0) {
			return i
		}
	}
	panic("not found 0")
}

func Up(in [9]byte) (bool, [9]byte) {
	pos := search(in)
	if pos > 2 {
		in[pos], in[pos-3] = in[pos-3], in[pos]
	} else {
		return false, in
	}
	return true, in
}

func Down(in [9]byte) (bool, [9]byte) {
	pos := search(in)
	if pos < 6 {
		in[pos], in[pos+3] = in[pos+3], in[pos]
	} else {
		return false, in
	}
	return true, in

}

func Left(in [9]byte) (bool, [9]byte) {
	pos := search(in)
	// mod(pos, 3) == 0
	if pos != 0 && pos != 3 && pos != 6 {
		in[pos], in[pos-1] = in[pos-1], in[pos]
	} else {
		return false, in
	}
	return true, in

}
func Right(in [9]byte) (bool, [9]byte) {
	pos := search(in)
	// mod(pos, 3) == 2
	if pos != 2 && pos != 5 && pos != 8 {
		in[pos], in[pos+1] = in[pos+1], in[pos]
	} else {
		return false, in
	}
	return true, in
}

func nextInt() int {
	sc.Scan()
	i, _ := strconv.Atoi(sc.Text())
	return i
}

var goal = [9]byte{1, 2, 3, 4, 5, 6, 7, 8, 0}

type item struct {
	d *[9]byte
	c int
}

var queue = []item{}
var closed = map[[9]byte]bool{}

func bfs(cost int) int {
	for {
		top := queue[0]
		queue = queue[1:]

		if *top.d == goal {
			return top.c
		}
		closed[*top.d] = true

		ok, ur := Up(*top.d)
		ok2, _ := closed[ur]
		if ok && !ok2 {
			queue = append(queue, item{&ur, top.c + 1})
		}
		ok, dr := Down(*top.d)
		ok2, _ = closed[dr]
		if ok && !ok2 {
			queue = append(queue, item{&dr, top.c + 1})
		}
		ok, lr := Left(*top.d)
		ok2, _ = closed[lr]
		if ok && !ok2 {
			queue = append(queue, item{&lr, top.c + 1})
		}
		ok, rr := Right(*top.d)
		ok2, _ = closed[rr]
		if ok && !ok2 {
			queue = append(queue, item{&rr, top.c + 1})
		}
	}
}

func main() {
	sc.Split(bufio.ScanWords)
	var state [9]byte
	for i := 0; i < 9; i++ {
		state[i] = byte(nextInt())
	}
	queue = append(queue, item{&state, 0})
	cost := bfs(0)
	fmt.Println(cost)
}
