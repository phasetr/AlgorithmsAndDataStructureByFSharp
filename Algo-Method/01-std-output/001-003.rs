fn main() {
    println!("{}", 27182 % 818);
}

fn add(a: i32, b: i32) -> i32 {
    a + b
}

#[cfg(test)]
mod tests {
    use super::*;
    #[test]
    fn add_test() {
        assert_eq!(2, add(1, 1));
    }
}
