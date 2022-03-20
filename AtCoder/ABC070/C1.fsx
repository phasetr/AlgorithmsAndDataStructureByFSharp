@"https://atcoder.jp/contests/abc070/tasks/abc070_c
* 1≦N≦100
* 1≦T_i≦10^{18}
* 入力は全て整数である。
* 答えは 10^{18} 秒以内である。"
#r "nuget: FsUnit"
open FsUnit

@"最小公倍数を取ればよさそうだがはまりどころはどこか?"
let solve N Ta =
    let gcd: bigint -> bigint -> bigint = fun x y ->
        let rec frec x y = if y=0I then x else frec y (x%y)
        if x >= y then frec x y else frec y x
    let lcm a b = a * b / (gcd a b)
    (1I,Ta) ||> Array.fold (fun acc ti -> lcm acc ti)
let N = stdin.ReadLine() |> int
let Ta = [| for i in 1..N do (stdin.ReadLine() |> bigint.Parse) |]
solve N Ta |> stdout.WriteLine

solve 2 [|2I;3I|] |> should equal 6I
solve 5 [|2I;5I;10I;1000000000000000000I;1000000000000000000I|] |> should equal 1000000000000000000I
