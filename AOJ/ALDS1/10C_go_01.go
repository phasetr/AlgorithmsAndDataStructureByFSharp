// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_C/review/5221778/EternalRookie/Go
package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

func createScanner() *bufio.Scanner {
	if len(os.Args) > 1 && os.Args[1] == "TEST" {
		fp, err := os.Open("write.txt")
		if err != nil {
			panic(err)
		}

		return bufio.NewScanner(fp)
	}

	return bufio.NewScanner(os.Stdin)
}

var sc = createScanner()

func nextInt() int {
	sc.Scan()
	i, _ := strconv.Atoi(sc.Text())

	return i
}

// XiとYiのLCS -> xi==yiならX_i-1とY_i-1のLCSにxiを足したもの
// xi!=yiならX_i-1とY_iのLCSとX_iとY_i-1のLCSのうち、長いほうがXiとYiのLCS
func main() {
	num := nextInt()
	for i := 0; i < num; i++ {
		table := [1001][1001]uint16{}
		sc.Scan()
		a := sc.Text()
		sc.Scan()
		b := sc.Text()
		max := uint16(0)
		for j := 1; j <= len(a); j++ {
			for k := 1; k <= len(b); k++ {
				xI := a[:j]
				yI := b[:k]
				if xI[len(xI)-1] == yI[len(yI)-1] {
					table[k][j] = table[k-1][j-1] + 1
					if max < table[k][j] {
						max = table[k][j]
					}
				} else {
					if table[k][j-1] > table[k-1][j] {
						table[k][j] = table[k][j-1]
					} else {
						table[k][j] = table[k-1][j]
					}
				}
			}
		}

		fmt.Println(max)
	}
}
