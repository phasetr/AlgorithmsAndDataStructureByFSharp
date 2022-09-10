// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_B/review/5274328/kshibata101/Go
package main

import (
	"bufio"
	"fmt"
	"os"
)

func main() {
	r := bufio.NewReader(os.Stdin)
	w := bufio.NewWriter(os.Stdout)
	defer w.Flush()

	var h int
	fmt.Fscan(r, &h)
	a := make([]int, h)
	for i := 0; i < h; i++ {
		fmt.Fscan(r, &a[i])
	}

	for i := h / 2; i >= 0; i-- {
		maxHeapify(&a, i)
	}
	for i := 0; i < h; i++ {
		fmt.Fprintf(w, " %d", a[i])
	}
	fmt.Fprintln(w)
}

func maxHeapify(a *[]int, i int) {
	l := 2*i + 1
	r := 2*i + 2

	// a[l], a[r], a[i]の最大探す
	k := i
	if l < len(*a) && (*a)[k] < (*a)[l] {
		k = l
	}
	if r < len(*a) && (*a)[k] < (*a)[r] {
		k = r
	}

	if k != i {
		(*a)[i], (*a)[k] = (*a)[k], (*a)[i]
		maxHeapify(a, k)
	}
}
