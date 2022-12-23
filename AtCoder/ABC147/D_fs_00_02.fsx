#r "nuget: FsUnit"
open FsUnit

@"2^60はint64"
(*
let N,Aa = 3L,[|1L;2L;3L|]
let N,Aa = 10L,[|3L;1L;4L;1L;5L;9L;2L;6L;5L;3L|]
let N,Aa = 10L,[|3L;14L;159L;2653L;58979L;323846L;2643383L;27950288L;419716939L;9375105820L|]
*)
let solve N Aa =
  let MOD = 1_000_000_007L
  let (.+) a b = ((a%MOD)+(b%MOD))%MOD
  let (.*) a b = ((a%MOD)*(b%MOD))%MOD
  [|0..60|]
  |> Array.map (fun i -> Aa |> Array.sumBy (fun a -> (a>>>i)%2L))
  |> fun Xa -> (0L,[|0..60|],Xa) |||> Array.fold2 (fun acc i y ->
    acc .+ ((pown 2L i) .* y .* (N-y)))

let N = stdin.ReadLine() |> int64
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N Aa |> stdout.WriteLine

solve 3L [|1L;2L;3L|] |> should equal 6L
solve 10L [|3L;1L;4L;1L;5L;9L;2L;6L;5L;3L|] |> should equal 237L
solve 10L [|3L;14L;159L;2653L;58979L;323846L;2643383L;27950288L;419716939L;9375105820L|] |> should equal 103715602L

[|0..5|]
|> Array.map (fun x ->
  Aa |> Array.map (fun a -> let z = (a>>>x) in (a, x, z, z%2L)))
|> Array.iter (printfn "%A")

Aa |> Array.map (fun a -> let z = (a>>>0) in (z, z%2L))
Aa |> Array.map (fun a -> let z = (a>>>1) in (z, z%2L))
