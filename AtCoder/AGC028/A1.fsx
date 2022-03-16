@"https://atcoder.jp/contests/agc028/tasks/agc028_a
- 1 \leq N,M \leq 10^5
- S, T は英小文字からなる。
- |S|=N
- |T|=M"
#r "nuget: FsUnit"
open FsUnit

@"以下のコードはTLE.
条件をみたす場合は最小公倍数になる.
最小公倍数を計算してから実際にXを作ろうとするとTLEになるから,
その点に注意して指定条件をみたす候補文字列を作って比較する.
その文字列の必要番号の整合性を確認する."
let N,M,S,T = 3L,2L,"acp","ae"
let N,M,S,T = 15L,9L,"dnsusrayukuaiia","dujrunuma"
let solve N M (S:string) (T:string) =
    let gcd: int64 -> int64 -> int64 = fun x y ->
        let rec locgcd x y =
            match y with
            | 0L -> x
            | _ -> locgcd y (x % y)
        if x >= y then locgcd x y else locgcd y x
    let lcm a b = a * b / (gcd a b)
    let L = lcm N M
    let n = L/N
    let m = L/M
    (true, [|1L..L|])
    ||> Array.fold (fun b i ->
        if b then
            let s = if (i-1L)%n=0L then string S.[int ((i-1L)/n)] else ""
            let t = if (i-1L)%m=0L then string T.[int ((i-1L)/m)] else ""
            if s="" || t="" || s=t then true else false
        else false)
    |> fun b -> if b then L else -1L
let N, M = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1])
let S = stdin.ReadLine()
let T = stdin.ReadLine()
solve N M S T |> stdout.WriteLine

solve 3L 2L "acp" "ae" |> should equal 6L
solve 6L 3L  "abcdef" "abc" |> should equal -1L
solve 15L 9L "dnsusrayukuaiia" "dujrunuma" |> should equal 45L
