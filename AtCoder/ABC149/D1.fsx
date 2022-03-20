@"https://atcoder.jp/contests/abc149/tasks/abc149_d
- 2 \leq N \leq 10^5
- 1 \leq K \leq N-1
- 1 \leq R,S,P \leq 10^4
- N,K,R,S,P は全て整数である。
- |T| = N
- T に含まれる文字は r , s , p のいずれかである。"
#r "nuget: FsUnit"
open FsUnit

@"K回前を覚えつつ処理すればよい.
K回前にあいこまたは負けているときは勝てることに注意する.
lK個ごとのチャンクにわける.
最後の行が少ない可能性があるので適当な文字で埋めて二次元配列を作る."
let solve N K R S P (T:string) =
    let f x y = if x+y*K < N then T.[x+y*K] else 'x'
    let t = Array2D.init K ((N/K)+1) (fun x y -> f x y)
    let win x = if x='r' then 'p' elif x='p' then 's' elif x='s' then 'r' else 'y'
    let point x = if x='r' then R elif x='p' then P elif x='s' then S else 0
    let rec g c score = function
        | a when Array.isEmpty a -> score
        | a ->
            let y = Array.head a
            let ys = Array.tail a
            if (c=win y) then (g 'x' score ys)
            else g (win y) (score + (point (win y))) ys
    [|0..(K-1)|]
    |> Array.map (fun i -> g 'x' 0 t.[i,0..])
    |> Array.sum
let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let R,S,P = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1], x.[2])
let T = stdin.ReadLine()
solve N K R S P T |> stdout.WriteLine

solve 5 2 8 7 6 "rsrpr" |> should equal 27
solve 7 1 100 10 1 "ssssppr" |> should equal 211
solve 30 5 325 234 123 "rspsspspsrpspsppprpsprpssprpsr" |> should equal 4996
