#r "nuget: FsUnit"
open FsUnit

(*
let N,S1,S2 = 3,"aab","ccb"
let N,S1,S2 = 1,"Z","Z"
let N,S1,S2 = 52,"RvvttdWIyyPPQFFZZssffEEkkaSSDKqcibbeYrhAljCCGGJppHHn","RLLwwdWIxxNNQUUXXVVMMooBBaggDKqcimmeYrhAljOOTTJuuzzn"
*)
let solve N (S1:string) (S2:string) =
  let MOD = 1_000_000_007L
  let (.*) x y = (x*y)%MOD

  let Na = [|6L;2L;3L|]
  let f b (acc,p) =
    if 2L<p then (acc, 2L)
    elif b then (acc.*(3L-p), 1L)
    else (acc .* Na.[int p], 3L)

  [|0..N-1|]
  |> Array.map (fun i -> S1.[i]=S2.[i])
  |> fun Aa -> Array.foldBack f Aa (1L,0L)
  |> fst

let N = stdin.ReadLine() |> int
let S1 = stdin.ReadLine()
let S2 = stdin.ReadLine()
solve N S1 S2 |> stdout.WriteLine

solve 3 "aab" "ccb" |> should equal 6
solve 1 "Z" "Z" |> should equal 3
solve 52 "RvvttdWIyyPPQFFZZssffEEkkaSSDKqcibbeYrhAljCCGGJppHHn" "RLLwwdWIxxNNQUUXXVVMMooBBaggDKqcimmeYrhAljOOTTJuuzzn" |> should equal 958681902
