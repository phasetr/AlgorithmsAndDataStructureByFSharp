// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_B/review/4683801/takezawa/Gopackage main
package main

import "fmt"

func main() {
	const Mod = int(1e9) + 7
	var m, n int
	fmt.Scan(&m, &n)
	ans := 1
	base := m
	for i := uint(0); i < 31; i++ {
		if n>>i&1 == 1 {
			ans = (ans * base) % Mod
		}
		base = (base * base) % Mod
	}
	fmt.Println(ans)
}
