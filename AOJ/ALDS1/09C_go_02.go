// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_C/review/5275519/kshibata101/Go
package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

type heap []int

func (h *heap) insert(v int) {
	*h = append(*h, v)
	for i := len(*h) - 1; i > 0; {
		j := (i - 1) / 2
		if (*h)[j] >= (*h)[i] {
			break
		}
		(*h)[j], (*h)[i] = (*h)[i], (*h)[j]
		i = j
	}
}

func (h *heap) maxHeapify(i int) {
	l := 2*i + 1
	r := 2*i + 2

	k := i
	if l < len(*h) && (*h)[k] < (*h)[l] {
		k = l
	}
	if r < len(*h) && (*h)[k] < (*h)[r] {
		k = r
	}
	if k != i {
		(*h)[k], (*h)[i] = (*h)[i], (*h)[k]
		h.maxHeapify(k)
	}
}

func (h *heap) extract() int {
	v := (*h)[0]
	(*h)[0] = (*h)[len(*h)-1]
	*h = (*h)[:len(*h)-1]
	h.maxHeapify(0)

	return v
}

func main() {
	s := bufio.NewScanner(os.Stdin)
	s.Split(bufio.ScanWords)
	// r := bufio.NewReader(os.Stdin)
	w := bufio.NewWriter(os.Stdout)
	defer w.Flush()

	var h heap = []int{}
	for {
		var c string
		// fmt.Fscan(r, &c)
		s.Scan()
		c = s.Text()
		if c == "insert" {
			var v int
			// fmt.Fscan(r, &v)
			s.Scan()
			v, _ = strconv.Atoi(s.Text())

			h.insert(v)
		} else if c == "extract" {
			fmt.Fprintln(w, h.extract())
		} else if c == "end" {
			break
		}
	}
}
