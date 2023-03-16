#r "nuget: FsUnit"
open FsUnit

(*
let N,P,Aa = 4,6L,[|1L;2L;3L;6L|]
let N,P,Aa = 4,1L,[|1000000008L;1000000008L;1000000008L;1000000008L|]
let N,P,Aa = 2,609777330L,[|31415926535897932L;384626433832795028L|]
let N,P,Aa = 10,0L,[|0L;0L;0L;0L;0L;1L;2L;3L;4L;5L|]
*)
let solve N P (Aa:int64[]) =
  let MOD = 1_000_000_007L
  let (.*) x y =  (x%MOD)*(y%MOD)%MOD
  let rec powm x n = if n=0 then 1L elif n&&&1=0 then powm (x.*x) (n/2) else x .* powm x (n-1)
  let h = System.Collections.Generic.Dictionary<int64,int64>()
  (0L,[|0..N-1|]) ||> Array.fold (fun acc i ->
    let a = Aa.[i]%MOD
    let cnt =
      if a=0L && P=0L then acc+(int64 i)
      else
        let v = P .* powm a (MOD-2L |> int)
        acc + (h.TryGetValue(v) |> function | true,n -> n | false,_ -> 0L)
    h.[a] <- 1L + (h.TryGetValue(a) |> function | true,n -> n | false,_ -> 0L)
    cnt)

let N,P = stdin.ReadLine().Split() |> (fun x -> int x.[0], int64 x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N P Aa |> stdout.WriteLine

solve 4 6L [|1L;2L;3L;6L|] |> should equal 2
solve 4 1L [|1000000008L;1000000008L;1000000008L;1000000008L|] |> should equal 6
solve 2 609777330L [|31415926535897932L;384626433832795028L|] |> should equal 1
solve 10 0L [|0L;0L;0L;0L;0L;1L;2L;3L;4L;5L|] |> should equal 35
