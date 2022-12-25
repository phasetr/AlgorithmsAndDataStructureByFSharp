// https://atcoder.jp/contests/code-festival-2017-quala/submissions/8537949
#![allow(non_snake_case)]
#![allow(unused_variables)]
#![allow(dead_code)]

fn main() {
    let (H, W): (usize, usize) = {
        let mut line: String = String::new();
        std::io::stdin().read_line(&mut line).unwrap();
        let mut iter = line.split_whitespace();
        (
            iter.next().unwrap().parse().unwrap(),
            iter.next().unwrap().parse().unwrap()
        )
    };
    let S: Vec<Vec<char>> = (0..H).map(|_| {
        let mut line: String = String::new();
        std::io::stdin().read_line(&mut line).unwrap();
        line.trim().chars().collect()
    }).collect();

    let mut c = std::collections::HashMap::new();
    for i in 0..H { for j in 0..W { *(c.entry(S[i][j]).or_insert(0)) += 1; } }
    let mut dp = vec![0, 0, 0, 0];
    for (_, &v) in &c { dp[v % 4] += 1; }

    let ans = if (H % 2 == 0 && W % 2 == 0 && dp[1] == 0 && dp[2] == 0 && dp[3] == 0) ||
        (H % 2 == 0 && W % 2 == 1 && dp[1] == 0 && dp[3] == 0 && dp[2] <= H / 2) ||
        (H % 2 == 1 && W % 2 == 0 && dp[1] == 0 && dp[3] == 0 && dp[2] <= W / 2) ||
        (H % 2 == 1 && W % 2 == 1 && dp[1] + dp[3] <= 1 && dp[2] + dp[3] <= H / 2 + W / 2) { "Yes" }
        else { "No" };

    println!("{}", ans);
}
