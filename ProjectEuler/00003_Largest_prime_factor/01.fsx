// # Largest prime factor
// - [URL](https://projecteuler.net/problem=3)
// ## Problem 3
// The prime factors of 13195 are 5, 7, 13 and 29.
// What is the largest prime factor of the number 600851475143?
//
// 13195 の素因数は 5, 7, 13, 29 である。
// 600851475143 の最大の素因数は何か？
let target = 600851475143L
// target |> double |> sqrt |> int64 |> printfn "%A"

let rec solve origN n divnum maxnum =
    // divnum < sqrt N まで確認すればいい
    if divnum * divnum < origN
    // divnum で割れたら、n を入れ替えてさらに divnum を因数に持たないかチェックする
    // divnum で割れないなら divnum を増やして再確認
    then if n % divnum = 0L then solve origN (n / divnum) divnum divnum else solve origN n (divnum + 1L) maxnum
    // divnum > sqrt N まで来たら origN が素数か素数でないかで場合分け
    else if n = 1L
    then maxnum
    else origN

solve target target 2L 1L
