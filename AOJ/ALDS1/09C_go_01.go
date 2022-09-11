// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_C/review/4764493/ccppjsrb/Go
package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

func configure(scanner *bufio.Scanner) {
	scanner.Split(bufio.ScanWords)
	scanner.Buffer(make([]byte, 1000005), 1000005)
}
func getNextString(scanner *bufio.Scanner) string {
	scanned := scanner.Scan()
	if !scanned {
		panic("scan failed")
	}
	return scanner.Text()
}
func getNextInt(scanner *bufio.Scanner) int {
	i, _ := strconv.Atoi(getNextString(scanner))
	return i
}
func getNextInt64(scanner *bufio.Scanner) int64 {
	i, _ := strconv.ParseInt(getNextString(scanner), 10, 64)
	return i
}
func getNextFloat64(scanner *bufio.Scanner) float64 {
	i, _ := strconv.ParseFloat(getNextString(scanner), 64)
	return i
}
func main() {
	fp := os.Stdin
	wfp := os.Stdout
	extra := 0
	if os.Getenv("I") == "IronMan" {
		fp, _ = os.Open(os.Getenv("END_GAME"))
		extra = 100
	}
	scanner := bufio.NewScanner(fp)
	configure(scanner)
	writer := bufio.NewWriter(wfp)
	defer func() {
		r := recover()
		if r != nil {
			fmt.Fprintln(writer, r)
		}
		writer.Flush()
	}()
	solve(scanner, writer)
	for i := 0; i < extra; i++ {
		fmt.Fprintln(writer, "-----------------------------------")
		solve(scanner, writer)
	}
}

func solve(scanner *bufio.Scanner, writer *bufio.Writer) {
	m := make(mheap, 2000000)
	for {
		s := getNextString(scanner)
		switch s {
		case "insert":
			m.push(getNextInt(scanner))
		case "extract":
			fmt.Fprintln(writer, m.pop())
		case "end":
			return
		}
	}
}

var n int

type mheap []int

func (m *mheap) pop() int {
	n--
	m.swap(0, n)
	m.down(0, n)
	x := (*m)[n]
	return x
}
func (m mheap) push(x int) {
	m[n] = x
	u, d := (n-1)>>1, n
	for d > 0 && m.less(d, u) {
		m.swap(d, u)
		d, u = u, (u-1)>>1
	}
	n++
}
func (m mheap) less(i, j int) bool {
	return m[i] > m[j]
}
func (m mheap) swap(i, j int) {
	m[i], m[j] = m[j], m[i]
}
func (m mheap) down(i, n int) {
	for {
		l := i<<1 + 1
		r := l + 1
		if r < n && m.less(r, l) {
			l = r
		}
		if l < n && m.less(l, i) {
			m.swap(i, l)
			i = l
			continue
		}
		break
	}
}

