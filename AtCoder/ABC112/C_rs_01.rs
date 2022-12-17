// https://atcoder.jp/contests/abc112/submissions/28109570
use proconio::input;

fn main() {
    input!{
        n: usize,
        xyh: [(i32, i32, i32); n],
    }

    let (x1, y1, h1) = xyh.iter().filter(|&&(_, _, h)| h > 0).next().unwrap();

    for cx in 0..=100 {
        for cy in 0..=100 {
            let h0 = h1 + (x1-cx).abs() + (y1-cy).abs();
            if xyh.iter().all(|&(x, y, h)| h == (h0 - (x-cx).abs() - (y-cy).abs()).max(0)) {
                println!("{} {} {}", cx, cy, h0);
                break;
            }
        }
    }
}
