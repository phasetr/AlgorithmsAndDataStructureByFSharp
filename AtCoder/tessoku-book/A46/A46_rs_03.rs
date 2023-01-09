// https://atcoder.jp/contests/tessoku-book/submissions/37755542
use proconio::{input, fastout};

#[allow(non_snake_case)]
#[fastout]
fn main() {
    input! {
        N: usize,
        XY: [(isize, isize); N]
    }
    let (X, Y): (Vec<_>, Vec<_>) = XY.into_iter().unzip();
    let mut visited = vec![false; N];
    let mut route = vec![1; N + 1];
    visited[0] = true;
    let mut current = 0;
    for i in 1..N {
        let mut min = (0, std::f64::MAX);
        for j in 1..N {
            if visited[j] {
                continue;
            }
            let dist = distance(X[j], Y[j], X[current], Y[current]);
            if dist < min.1 {
                min = (j, dist);
            }
        }
        visited[min.0] = true;
        route[i] = min.0 + 1; // 0-origin -> 1-origin
        current = min.0;
    }
    for ans in route {
        println!("{}", ans);
    }
}

fn distance(x1: isize, y1: isize, x2: isize, y2: isize) -> f64 {
    (((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)) as f64).sqrt()
}
