// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_B/review/3680510/ccppjsrb/Go
package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

func getScanner(fp *os.File) *bufio.Scanner {
	scanner := bufio.NewScanner(fp)
	scanner.Split(bufio.ScanWords)
	scanner.Buffer(make([]byte, 500001), 500000)
	return scanner
}

func getNextString(scanner *bufio.Scanner) string {
	scanner.Scan()
	return scanner.Text()
}

func getNextInt(scanner *bufio.Scanner) int {
	i, _ := strconv.Atoi(getNextString(scanner))
	return i
}

func main() {
	fp := os.Stdin
	if len(os.Args) > 1 {
		fp, _ = os.Open(os.Args[1])
	}

	scanner := getScanner(fp)
	writer := bufio.NewWriter(os.Stdout)

	n := getNextInt(scanner)

	g := makeGraph(n)
	for i := 0; i < n; i++ {
		u := getNextInt(scanner)
		k := getNextInt(scanner)
		for ii := 0; ii < k; ii++ {
			v := getNextInt(scanner)
			c := getNextInt(scanner)
			g[u][v] = c
		}
	}

	ans := make([]int, n)
	im := make(IntMap, 1)
	im.increment(0)
	for len(im) < n {
		min := 1 << 30
		x := -1
		for u := range im {
			for v := 0; v < n; v++ {
				if im.get(v) != 0 {
					continue
				}
				if min > ans[u]+g[u][v] {
					min = ans[u] + g[u][v]
					x = v
				}
			}
		}
		im.increment(x)
		ans[x] = min
	}

	for i := 0; i < n; i++ {
		fmt.Fprintln(writer, fmt.Sprintf("%d %d", i, ans[i]))
	}
	writer.Flush()
}

func makeGraph(n int) [][]int {
	g := make([][]int, n)
	for i := 0; i < n; i++ {
		g[i] = make([]int, n)
		for ii := 0; ii < n; ii++ {
			g[i][ii] = 1 << 30
		}
	}

	return g
}

// IntMap ...
type IntMap map[int]int

func (m IntMap) get(key int) int {
	if _, ok := m[key]; ok {
		return m[key]
	}
	return 0
}
func (m IntMap) increment(key int) {
	if _, ok := m[key]; ok == false {
		m[key] = 0
	}
	m[key]++
}
