// https://algo-method.com/submissions/258537
use std::io;

fn main() {
    let mut s = String::new();
    io::stdin().read_line(&mut s);

    let mut t = String::new();
    io::stdin().read_line(&mut t);

    println!("{}", if s.trim() == t.trim() {"Yes"} else {"No"});
}
