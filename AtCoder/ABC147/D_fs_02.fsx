// https://atcoder.jp/contests/abc147/submissions/13908633
(* Examples *)
(*
stdin.ReadLine()
printfn "%d"
printfn "%s"
*)

(* Library *)
module Library =
  let modPow x y m =
    let rec loop x y m result =
      match y with
      | 0L -> result
      | _ ->
        loop x (y - 1L) m ((result * x) % m)
    loop x y m 1L

(* Standard Input *)
let readSplit elementFun=
  stdin.ReadLine().Split()
  |> Array.map elementFun

let read elementFun =
  stdin.ReadLine() |> elementFun

let readMap H =
  [|for i in 1..H -> stdin.ReadLine()|]
  |> Array.map(fun line ->
    line.ToCharArray()
  )
  |> array2D

(* Main *)
open Library

let N = read int64
let A = readSplit int64
let m = pown 10L 9 + 7L

[|0..62|]
|> Array.map (fun x ->
  A
  |> Array.sumBy (fun y ->  (y >>> x) % 2L)
)
|> Array.fold2 (fun sum x y ->
  (sum + ((((pown 2L x) % m) * y % m) * (N - y)) % m) % m
) 0L [|0..62|]
|> printfn "%d"
