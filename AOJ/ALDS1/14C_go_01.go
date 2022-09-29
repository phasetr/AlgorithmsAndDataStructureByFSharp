// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_C/review/3659883/kshibata101/Go
package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

var BR uint64 = 9973
var BC uint64 = 100000007

func main() {
	var h, w, r, c int
	fmt.Scan(&h)
	fmt.Scan(&w)

	field := make([][]rune, h)
	sc := bufio.NewScanner(os.Stdin)
	sc.Split(bufio.ScanWords)
	for i := 0; i < h; i++ {
		sc.Scan()
		field[i] = []rune(sc.Text())
	}
	sc.Scan()
	r, _ = strconv.Atoi(sc.Text())
	sc.Scan()
	c, _ = strconv.Atoi(sc.Text())

	if h < r || w < c {
		return
	}

	pattern := make([][]rune, r)
	for i := 0; i < r; i++ {
		sc.Scan()
		pattern[i] = []rune(sc.Text())
	}

	ph1 := make([]uint64, r)
	var ph2 uint64 = 0
	for i := 0; i < r; i++ {
		for j := 0; j < c; j++ {
			ph1[i] = uint64(pattern[i][j]) + ph1[i]*BR
		}
		ph2 = ph1[i] + ph2*BC
	}

	var brc, bcr uint64 = 1, 1
	for i := 0; i < c; i++ {
		brc *= BR
	}
	for i := 0; i < r; i++ {
		bcr *= BC
	}

	fh1 := make([][]uint64, h)
	for i := 0; i < h; i++ {
		fh1[i] = make([]uint64, w-c+1)
		for j := 0; j < c; j++ {
			fh1[i][0] = uint64(field[i][j]) + fh1[i][0]*BR
		}
		for j := 1; j <= w-c; j++ {
			fh1[i][j] = fh1[i][j-1]*BR + uint64(field[i][j+c-1]) - uint64(field[i][j-1])*brc
		}
	}

	fh2 := make([][]uint64, h-r+1)
	for j := 0; j <= w-c; j++ {
		if j == 0 {
			fh2[0] = make([]uint64, w-c+1)
		}
		for i := 0; i < r; i++ {
			fh2[0][j] = fh1[i][j] + fh2[0][j]*BC
		}
		for i := 1; i <= h-r; i++ {
			if j == 0 {
				fh2[i] = make([]uint64, w-c+1)
			}
			fh2[i][j] = fh2[i-1][j]*BC + fh1[i+r-1][j] - fh1[i-1][j]*bcr
		}
	}

	wr := bufio.NewWriter(os.Stdout)
	for i := 0; i <= h-r; i++ {
		for j := 0; j <= w-c; j++ {
			if fh2[i][j] == ph2 {
				wr.WriteString(strconv.Itoa(i) + " " + strconv.Itoa(j) + "\n")
			}
		}
	}
	wr.Flush()
}
