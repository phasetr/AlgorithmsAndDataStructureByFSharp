// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_A/review/3658873/kshibata101/Go
package main

import "fmt"

func main() {
	var t, p string
	fmt.Scan(&t)
	fmt.Scan(&p)

	runes := []rune(t)
	psize := len([]rune(p))
	for i := 0; i < len(runes); i++ {
		l := len(runes)
		if i+psize > l {
			continue
		}
		if string(runes[i:i+psize]) == p {
			fmt.Println(i)
		}
	}
}
