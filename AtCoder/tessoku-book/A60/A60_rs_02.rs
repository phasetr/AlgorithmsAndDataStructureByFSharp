// https://atcoder.jp/contests/tessoku-book/submissions/36499165
use proconio::input;

fn main() {
    input! {
        n: usize,
        a: [i64; n]
    };

    let mut stack: Vec<(usize, i64)> = Vec::new();

    let mut answer: Vec<i64> = vec![-2; n];
    for i in 1..n {
        stack.push((i - 1, a[i - 1]));

        while let Some(tail) = stack.last() {
            if tail.1 <= a[i] {
                stack.pop();
            } else {
                break;
            }
        }

        if !stack.is_empty() {
            answer[i] = stack.last().unwrap().0 as i64;
        }
    }

    println!(
        "{}",
        answer
            .iter()
            .map(|x| (x + 1).to_string())
            .collect::<Vec<String>>()
            .join(" ")
    );
}
