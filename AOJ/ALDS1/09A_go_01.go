// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_A/review/4125443/numpy/Go
package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

var scanner = bufio.NewScanner(os.Stdin)

func nextString() string {
	scanner.Scan()
	return scanner.Text()
}

func nextInt() (int, error) {
	return strconv.Atoi(nextString())
}

func main() {
	scanner.Split(bufio.ScanWords)

	h, _ := nextInt()
	arr := make([]int, h)
	for i := range arr {
		arr[i], _ = nextInt()
	}

	for i := range arr {
		fmt.Printf("node %d: key = %d, ", i+1, arr[i])
		if i != 0 {
			fmt.Printf("parent key = %d, ", arr[(i-1)/2])
		}
		if i < len(arr)/2 {
			fmt.Printf("left key = %d, ", arr[2*i+1])
			if 2*(i+1) < len(arr) {
				fmt.Printf("right key = %d, ", arr[2*(i+1)])
			}
		}
		fmt.Println("")
	}
}
