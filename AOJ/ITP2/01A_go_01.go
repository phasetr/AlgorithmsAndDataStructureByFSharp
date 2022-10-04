// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP2_1_A/review/4114466/numpy/Go
package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

var scanner = bufio.NewScanner(os.Stdin)

func nextInt() (int, error) {
	scanner.Scan()
	return strconv.Atoi(scanner.Text())
}

func main() {
	scanner.Split(bufio.ScanWords)
	nQueries, _ := nextInt()
	arr := []int{}
	for i := 0; i < nQueries; i++ {
		queryType, _ := nextInt()

		if queryType == 0 {
			n, _ := nextInt()
			arr = append(arr, n)
		} else if queryType == 1 {
			n, _ := nextInt()
			fmt.Println(arr[n])
		} else {
			arr = arr[0:(len(arr) - 1)]
		}
	}
}
