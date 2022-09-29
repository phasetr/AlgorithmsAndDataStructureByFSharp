// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_A/review/3725799/GO_is_GOD/Go
package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

var sc = bufio.NewScanner(os.Stdin)

// PrimeFactorize .
func PrimeFactorize(n int) (ans []int) {
	for n%2 == 0 {
		ans = append(ans, 2)
		n /= 2
	}

	for i := 3; i*i <= n; i += 2 {
		for n%i == 0 {
			ans = append(ans, i)
			n /= i
		}
	}

	if n > 2 {
		ans = append(ans, n)
	}

	return ans
}

func main() {
	sc.Scan()
	n, _ := strconv.Atoi(sc.Text())
	ans := PrimeFactorize(n)
	//fmt.Println(ans)
	fmt.Printf("%d:", n)
	for _, s := range ans {
		fmt.Printf(" %d", s)
	}
	fmt.Println()
}
