use proconio::input;
use itertools::Itertools;

fn solve(n:usize,av:Vec<usize>,bv:Vec<usize>) -> Vec<usize> {
    let mut dp = vec![0; n];
    dp[1] = av[0];
    for i in 0..(n-2) {
        dp[i+2] = (dp[i] + bv[i]).min(dp[i+1] + av[i+1]);
    }

    let mut v = vec![n-1];
    loop {
        let mut i = *v.last().unwrap();
        if i == 0 {
            break;
        }

        if dp[i-1] + av[i-1] == dp[i] {
            i -= 1;
        } else {
            i -= 2;
        }
        v.push(i);
    }

    v.iter().rev().map(|&x| x+1).collect()
}
#[proconio::fastout]
fn main() {
    input! {
        n: usize,
        av: [usize; n-1],
        bv: [usize; n-2],
    }
    let v = solve(n,av,bv);
    println!("{}", v.len());
    println!("{}", v.iter().rev().map(|&x| x+1).join(" "));
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test1() {
        let (n,av,bv):(usize,Vec<usize>,Vec<usize>) = (5,vec![2,4,1,3],vec![5,3,3]);
        println!("{:?}", solve(n,av,bv));
        // vec![1,2,4,5]
        let (n,av,bv):(usize,Vec<usize>,Vec<usize>) = (10, vec![1,19,75,37,17,16,33,18,22], vec![41,28,89,74,98,43,42,31]);
        println!("{:?}", solve(n,av,bv));
        // vec![1,2,4,5,6,8,10]
        let (n,av,bv):(usize,Vec<usize>,Vec<usize>) = (3, vec![16,56], vec![67]);
        println!("{:?}", solve(n,av,bv));
        // vec![1,3]
        let (n,av,bv):(usize,Vec<usize>,Vec<usize>) = (5, vec![13,45,14,45], vec![22,39,25]);
        println!("{:?}", solve(n,av,bv));
        // vec![1,3,5]
    }
}
