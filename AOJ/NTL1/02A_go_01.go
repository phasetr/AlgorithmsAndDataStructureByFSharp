// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_2_A/review/5608332/yutaro1985/Go
package main

import (
	"fmt"
	"math/big"
)

func main() {
	var A, B string
	Ab, Bb := new(big.Int), new(big.Int)
	fmt.Scan(&A, &B)
	_, _ = fmt.Sscan(A, Ab)
	_, _ = fmt.Sscan(B, Bb)
	sum := Ab.Add(Ab, Bb)
	fmt.Println(sum)
}
