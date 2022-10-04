// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP2_1_A/review/6050375/jj_/Go
package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

var sc = bufio.NewScanner(os.Stdin)

func nextInt() int {
	sc.Scan()
	i, e := strconv.Atoi(sc.Text())
	if e != nil {
		panic(e)
	}
	return i
}

type Vector []int

func (v *Vector) pushBack(x int) {
	*v = append((*v), x)
}

func (v Vector) randomAccess(i int) int {
	return v[i]
}

func (v *Vector) popBack() {
	*v = (*v)[:len(*v)-1]
}

func main() {
	sc.Split(bufio.ScanWords)

	var v Vector

	q := nextInt()

	for i := 0; i < q; i++ {
		t := nextInt()
		if t == 0 {
			x := nextInt()
			v.pushBack(x)
		} else if t == 1 {
			p := nextInt()
			fmt.Println(v.randomAccess(p))
		} else {
			v.popBack()
		}
	}
}
