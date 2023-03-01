// https://atcoder.jp/contests/tessoku-book/submissions/37730127
use proconio::input;

struct BinaryIndexTree {
    size: i64,
    array: Vec<i64>
}

impl BinaryIndexTree {
    fn new(size: i64) -> BinaryIndexTree {
        return BinaryIndexTree { size: size, array: vec![0; (size + 1) as usize] }
    }

    fn add(&mut self, x: i64, a: i64) {
        let mut index = x;
        while index <= self.size {
            self.array[index as usize] += a;
            index += index & (-index);
        }
    }

    fn sum(&self, x: i64) -> i64 {
        let mut index = x;
        let mut answer = 0;
        while index > 0 {
            answer += self.array[index as usize];
            index -= index & (-index);
        }
        return answer;
    }
}

fn main() {
    input! {
        n: i64,
        a: [i64;n],
    }

    let mut bit = BinaryIndexTree::new(n + 1);
    let mut answer = 0;
    for i in 0..a.len() {
        let value = a[i];

        let ans = (i as i64) - bit.sum(value);
        answer += ans;

        bit.add(value, 1)
    }
    println!("{}", answer)
}
