// https://atcoder.jp/contests/agc033/submissions/17876580
fn main() {
    proconio::input! {
        h: usize,
        w: usize,
        a: [String; h],
    }
    let mut u = vec![vec![std::u32::MAX; w]; h];
    let mut q = std::collections::VecDeque::new();
    for (i, a) in a.into_iter().enumerate() {
        for (j, a) in a.into_bytes().into_iter().enumerate() {
            if a == b'#' {
                u[i][j] = 0;
                q.push_back((i, j));
            }
        }
    }
    let mut c = 0;
    while let Some((i, j)) = q.pop_front() {
        c = u[i][j];
        let dxy = [0, !0, 0, 1, 0];
        for k in 0..4 {
            let i = i.wrapping_add(dxy[k]);
            let j = j.wrapping_add(dxy[k + 1]);
            if i < h && j < w && u[i][j] > c + 1 {
                u[i][j] = c + 1;
                q.push_back((i, j));
            }
        }
    }
    println!("{}", c);
}
