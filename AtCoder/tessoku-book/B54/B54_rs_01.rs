// https://atcoder.jp/contests/tessoku-book/submissions/36561454
fn main() {
    proconio::input!{
        n: usize,
        mut a_s: [i32; n]
    };
    a_s.sort();
    let a_s = a_s;
    let mut answer = 0;
    let mut cursor = 0;
    for i in 1..n {
        if a_s[cursor] != a_s[i] {
            cursor = i;
        } else {
            answer += (i - cursor) as i64;
        }
    }
    println!("{}", answer);
}
