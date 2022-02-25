@"https://atcoder.jp/contests/abc131/tasks/abc131_c
1\leq A\leq B\leq 10^{18}
1\leq C,D\leq 10^9
入力はすべて整数である"
#r "nuget: FsUnit"
open FsUnit

@"数が多いのでふつうに考えたのでは間に合わない.
ほしいのは条件をみたす数の「個数」だから,
個数にフォーカスして考える.
特に全数からCの倍数とDの倍数を除けばよく,
重複(CとDの公倍数)に注意して引き算すればよい.
AとBがC・Dより小さい可能性もある.
また重複については計算のときCとDの「最小」公倍数を使うこと.

ここでは解説に準じて条件をみたすB以下の数とA-1以下の数を個別に計算してそれを引く."
let solve A B C D =
    let rec gcd: int64 -> int64 -> int64 = fun a b ->
        if a = 0L then b
        elif a < b then gcd a (b - a)
        else gcd (a - b) b
    let lcm a b = a * b / (gcd a b)

    let lcmcd = lcm C D
    (B - B/C - B/D + B/lcmcd) - ((A-1L) - (A-1L)/C - (A-1L)/D + (A-1L)/lcmcd)

let A,B,C,D = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1], x.[2], x.[3])
solve A B C D |> stdout.WriteLine

solve 4L 9L 2L 3L |> should equal 2L
solve 10L 40L 6L 8L |> should equal 23L
solve 314159265358979323L 846264338327950288L 419716939L 937510582L |> should equal 532105071133627368L
