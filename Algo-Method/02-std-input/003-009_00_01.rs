// M-x evcxr (evcxr)
fn input() -> String {
    let mut t = String::new();
    std::io::stdin().read_line(&mut t).unwrap();
    t.trim().to_string()
}
fn input_lines(n: i32) -> Vec<String> {
    let mut v: Vec<String> = Vec::new();
    for _ in 0..n {
        v.push(input());
    }
    v
}

fn solve(n:i32, inputs:Vec<String>) -> Vec<char> {
    let mut ans: Vec<char> = Vec::new();
    for i in 0..n {
        ans.push(inputs[i as usize].trim().chars().nth(0usize).unwrap());
    }
    ans
}

fn main() {
    let n: i32 = input().parse().unwrap();
    let inputs: Vec<String> = input_lines(n);
    let ans = solve(n,inputs);
    println!("{}", ans.into_iter().collect::<String>());
}

fn test() {
    let n: i32 = 4;
    let inputs = vec!("hyper","text","transfer","protocol");
    assert_eq!(solve(n,inputs), vec!('h','t','t','p'));
    println!("{:?}", solve(n,inputs));
    println!("{:?}", inputs[0]);
    println!("{:?}", inputs[1].chars().nth(0usize).unwrap());
}
