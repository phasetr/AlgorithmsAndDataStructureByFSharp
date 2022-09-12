// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_D/review/5305955/kshibata101/Go
package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"strings"
)

func maxHeapify(a *[]int, i, size int) {
	l, r, mx := 2*i+1, 2*i+2, i
	if l < size && (*a)[l] > (*a)[mx] {
		mx = l
	}
	if r < size && (*a)[r] > (*a)[mx] {
		mx = r
	}
	if mx != i {
		(*a)[i], (*a)[mx] = (*a)[mx], (*a)[i]
		maxHeapify(a, mx, size)
	}
}

func heapSort(a *[]int) {
	n := len(*a)
	for i := n/2 - 1; i >= 0; i-- {
		maxHeapify(a, i, n)
	}

	for size := n - 1; size > 0; size-- {
		(*a)[0], (*a)[size] = (*a)[size], (*a)[0]
		maxHeapify(a, 0, size)
	}
}

func main() {
	s := bufio.NewScanner(os.Stdin)
	s.Split(bufio.ScanWords)

	s.Scan()
	n, _ := strconv.Atoi(s.Text())

	a := make([]int, n)
	for i := 0; i < n; i++ {
		s.Scan()
		a[i], _ = strconv.Atoi(s.Text())
	}
	heapSort(&a)

	for i := 1; i < n; i++ {
		j := i - 1
		for j > 0 {
			p := (j - 1) / 2
			a[j], a[p] = a[p], a[j]
			j = p
		}
		a[0], a[i] = a[i], a[0]
	}
	fmt.Println(strings.Trim(fmt.Sprint(a), "[]"))
}

