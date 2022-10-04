// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP2_1_A/review/5962665/Lettuce1248/Go
package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"strings"
)

func main() {
	var length int
	fmt.Scanln(&length)
	var query []string
	var sc = bufio.NewScanner(os.Stdin)
	for i := 0; i < length; i++ {
		sc.Scan()
		var slice = strings.Split(sc.Text(), " ")
		switch slice[0] {
		case "0":
			query = append(query, slice[1])
		case "1":
			var num, _ = strconv.Atoi(slice[1])
			fmt.Println(query[num])
		case "2":
			query = query[:len(query)-1]
		}
	}
}
