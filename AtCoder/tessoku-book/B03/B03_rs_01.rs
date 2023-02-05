// https://atcoder.jp/contests/tessoku-book/submissions/36219912
fn main(){
    proconio::input!{n: usize, mut a: [usize; n]}
    a.sort();
    for i in 0 .. n {
        for j in i + 1 .. n {
            if a[j + 1 .. n].binary_search(&(1000 - a[i] - a[j])).is_ok() {
                println!("Yes");
                return;
            }
        }
    }
    println!("No");
}
