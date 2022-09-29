// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_D/review/4606271/tutuz/Go
package main

import (
	"bufio"
	"fmt"
	"index/suffixarray"
	"os"
)

func main() {
	r := bufio.NewReader(os.Stdin)
	w := bufio.NewWriter(os.Stdout)
	defer w.Flush()

	var s string
	var q int

	fmt.Fscan(r, &s)
	fmt.Fscan(r, &q)

	index := suffixarray.New([]byte(s))

	for i := 0; i < q; i++ {
		var p string
		fmt.Fscan(r, &p)

		res := index.Lookup([]byte(p), 1)
		if len(res) > 0 {
			fmt.Fprintln(w, 1)
		} else {
			fmt.Fprintln(w, 0)
		}
	}
}
