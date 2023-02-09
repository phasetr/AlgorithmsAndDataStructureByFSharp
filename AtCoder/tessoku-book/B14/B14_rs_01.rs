// https://atcoder.jp/contests/tessoku-book/submissions/36303717
fn main() {
    proconio::input!{n: usize, k: u64, mut a: [u64; n]}
    a.sort_by(|a, b| b.cmp(a));
    let r = match dfs(a.as_slice(), 0, k) {
        true => "Yes",
        false => "No"
    };
    println!("{}", r);
}

fn dfs(array: &[u64], total: u64, target: u64) -> bool {
    if total > target || total + array.iter().sum::<u64>() < target {
        return false;
    }
    let mut result = total == target;
    for i in 0 .. array.len() {
        result |= dfs(&array[i + 1 .. ], total + array[i], target);
    }
    result
}
