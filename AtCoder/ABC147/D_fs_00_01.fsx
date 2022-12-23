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
  let pow2 = Array.scan (*) 1L (Array.replicate 61 2L)
  let Xa =
    (Array.zeroCreate 60, Aa)
    ||> Array.fold (fun Xa n ->
      for i in 0..61 do let mask = 1L<<<i in if n&&&mask<>0L then Array.set Xa i (Xa.[i]+1L)
      Xa)
  (0L, [|0..60|]) ||> Array.fold (fun acc i -> acc .+ (Xa.[i] .* (N-Xa.[i]) .* pow2.[i]))

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map (fun x -> (parse x)%MODB)
solve N Aa |> stdout.WriteLine

solve 3L [|1L;2L;3L|] |> should equal 6L
solve 10L [|3L;1L;4L;1L;5L;9L;2L;6L;5L;3L|] |> should equal 237L
solve 10L [|3L;14L;159L;2653L;58979L;323846L;2643383L;27950288L;419716939L;9375105820L|] |> should equal 103715602L
