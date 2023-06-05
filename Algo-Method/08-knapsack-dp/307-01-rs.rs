fn solve(n:&i32, a:&Vec<i32>) -> i32 {
    a.iter().filter(|&x| x>&0).into_iter().sum::<i32>()
}
fn main() {
    let mut n0 = String::new();
    std::io::stdin().read_line(&mut n0).expect("");
    let n = n0.trim().parse().unwrap();

    let mut s0 = String::new();
    std::io::stdin().read_line(&mut s0).unwrap();
    let a = s0.trim().split_whitespace().map(|i| i.parse::<i32>().ok().unwrap()).collect::<Vec<_>>();
    println!("{}", solve(&n,&a));
}

fn test() {
    let mut n = 3;
    let mut a = vec![7,-6,9];
    println!("{}", solve(&n,&a) == 16);

    let mut n = 2;
    let mut a = vec![-9,-16];
    println!("{}", solve(&n,&a) == 0);
}
