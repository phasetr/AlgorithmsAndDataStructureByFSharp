(*
https://atcoder.jp/contests/abc169/tasks/abc169_d
http://www4.airnet.ne.jp/tmt/trimmhs/trimg44.pdf
https://atcoder.jp/contests/ABC169/submissions/13812146
Haskell の primeFactors と同じ実装を使っているが、
大きな素数に対して重くて使い物にならない。
*)

// https://stackoverflow.com/questions/1749569/is-it-possible-to-match-with-decomposed-sequences-in-f
open System

// Util start
// return! を使った再帰ではなく mutable を使っているのは return! で生成されるステートマシンのコストが（数を出して1増やすだけの処理より）普通に高いため
let initInfinite64 f =
    seq {
        let mutable i = 0L
        while true do
            yield f i
            i <- i + 1L
    }

let (|SeqEmpty|SeqCons|) (xs: 'a seq) =
    if Seq.isEmpty xs then SeqEmpty else SeqCons(Seq.head xs, Seq.skip 1 xs)

let rec group xs: seq<seq<'a>> =
    match xs with
    | SeqEmpty -> Seq.empty
    | SeqCons (x, xs) ->
        let ys: 'a seq = Seq.takeWhile ((=) x) xs
        let zs: 'a seq = Seq.skipWhile ((=) x) xs
        Seq.append (seq { Seq.append (seq { x }) ys }) (group zs)
// Util end

let rec go n pps =
    match pps with
    | SeqEmpty -> seq [ n ]
    | SeqCons (p: int64, ps) ->
        printfn "%d" p
        if n < p * p then seq [ n ] // p < \sqrt{n} まで調べればいい事案
        else
            let (q, r) = Math.DivRem(n, p)
            if r > 0L then go n ps
            else Seq.append (seq { p }) (go q pps)

// Haskell の primeFactor と本質的に同じコード
// http://hackage.haskell.org/package/primes-0.2.1.0/docs/src/Data-Numbers-Primes.html#primeFactors
// 上のページにもあるように、巨大な素数に対しては著しくパフォーマンスが落ちる
let primeFactors n =
    if n < 2L then
        Seq.empty
    else
        // 2 以上の自然数
        let int2s: int64 seq = initInfinite64 ((+) 2L)
        go n int2s

// let isPrime n = [ n ] = primeFactors n

let calc n =
    initInfinite64 (fun i -> (i + 1L) * (i + 2L) / 2L)
    |> Seq.takeWhile (fun x -> x <= n)
    |> Seq.length

let solve n =
    if n = 1L then
        0
    else
        primeFactors n
        |> group
        |> Seq.sumBy (Seq.length >> int64 >> calc)

let isDev = true

let fd =
    if isDev then
        solve 24L |> printfn "%d"
        solve 1L |> printfn "%d"
        solve 64L |> printfn "%d"
        //solve 1000000007L |> printfn "%d"
    else
        let n = stdin.ReadLine() |> int64
        solve n |> printfn "%d"

fd
