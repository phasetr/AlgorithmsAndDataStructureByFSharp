@"https://atcoder.jp/contests/abc061/tasks/abc061_c
* 1≦N≦10^5
* 1≦a_i,b_i≦10^5
* 1≦K≦b_1…+…b_n
* 入力は全て整数である。 "
#r "nuget: FsUnit"
open FsUnit

let solve N (K:int64) Aa =
    let rec frec k = function
        | [] -> 1L
        | (a,b)::xs -> if b<k then frec (k-b) xs else a
    Aa |> Array.sortBy fst |> Array.toList |> frec K
let N,K = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1])
let Aa = [| for i in 1L..N do (stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1])) |]
solve N K Aa |> stdout.WriteLine

solve 3L 4L [|(1L,1L);(2L,2L);(3L,3L)|] |> should equal 3L
solve 10L 500000L [|(1L,100000L);(1L,100000L);(1L,100000L);(1L,100000L);(1L,100000L);(100000L,100000L);(100000L,100000L);(100000L,100000L);(100000L,100000L);(100000L,100000L)|] |> should equal 1L
