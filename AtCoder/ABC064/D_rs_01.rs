// https://atcoder.jp/contests/abc064/submissions/14937395
fn main() {
    proconio::input!{
        n: usize,
        s: String,
    }

    let cs: Vec<char> = s.chars().collect();

    let mut stack = 0;
    let mut err = 0;
    for i in 0..n {
        if cs[i] == '(' {
            stack += 1;
        }
        else {
            if stack > 0 {
                stack -= 1;
            }
            else {
                err += 1;
            }
        }
    }
    for _i in 0..err {
        print!("(");
    }
    print!("{}", s);
    for _i in 0..stack {
        print!(")");
    }
    println!("");
}
