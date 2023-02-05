// https://atcoder.jp/contests/tessoku-book/submissions/38031322
use proconio::input;

fn divnum(x: usize, a: &[usize]) -> usize {
    let mut num = 0;
    let mut y = 0;
    for a in a.windows(2) {
        y += a[1] - a[0];
        if y >= x {
            num += 1;
            y = 0;
        }
    }
    num
}

fn main() {
    input! {
        n: usize,
        l: usize,
        k: usize,
        mut a: [usize; n],
    }

    a.insert(0, 0);
    a.push(l);

    let mut x0 = 1;
    let mut x1 = (l + k - 1) / k;
    while x1 - x0 > 1 {
        let x = (x0 + x1) / 2;
        if divnum(x, &a) > k {
            x0 = x;
        } else {
            x1 = x;
        }
    }
    println!("{}", x0);
}
