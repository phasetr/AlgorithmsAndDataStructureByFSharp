// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP2_1_B/review/3243679/muroya2355/Go
package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

func main() {

	var A [800000]string
	var n int
	fmt.Scan(&n)

	first_idx := 400000
	last_idx := 400000
	var scanner = bufio.NewScanner(os.Stdin)
	scanner.Split(bufio.ScanWords)

	for i := 0; i < n; i++ {

		scanner.Scan()
		query, _ := strconv.Atoi(scanner.Text())

		switch query {
		case 0:
			scanner.Scan()
			d, _ := strconv.Atoi(scanner.Text())
			scanner.Scan()
			x := scanner.Text()
			switch d {
			case 0:
				if i > 0 {
					first_idx--
				}
				A[first_idx] = x
			case 1:
				if i > 0 {
					last_idx++
				}
				A[last_idx] = x
			}
		case 1:
			scanner.Scan()
			p, _ := strconv.Atoi(scanner.Text())
			fmt.Println(A[p+first_idx])
		case 2:
			scanner.Scan()
			d, _ := strconv.Atoi(scanner.Text())
			switch d {
			case 0:
				A[first_idx] = "NULL"
				first_idx++
			case 1:
				A[last_idx] = "NULL"
				last_idx--
			}
		}
	}
}
