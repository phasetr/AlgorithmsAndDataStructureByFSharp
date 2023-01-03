// https://atcoder.jp/contests/tessoku-book/submissions/36541743
fn main() {
    proconio::input!{
        n: usize,
        x: usize,
        y: usize,
        a_s: [usize; n]
    };

    const A_MAX: usize = 100000;

    let mut g_s = Vec::new();
    for i in 0..=A_MAX {
        let mut v_s = vec![false; 3];
        if i >= x {
            v_s[g_s[i - x]] = true;
        }
        if i >= y {
            v_s[g_s[i - y]] = true;
        }
        let g = if !v_s[0] { 0 } else if !v_s[1] { 1 } else { 2 };
        g_s.push(g);
    }

    let mut xor_sum = 0;
    for a in a_s {
        xor_sum ^= g_s[a];
    }
    println!("{}", if xor_sum != 0 { "First" } else { "Second" });
}
