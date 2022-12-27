#r "nuget: FsUnit"
open FsUnit

(*
let N,Q,Aa,Ia = 10,5,[|8;6;9;1;2;1;10;100;1000;10000|],[|(2,3);(1,4);(3,9);(6,8);(1,10)|]
*)
let solve N Q (Aa:int[]) (Ia:(int*int)[]) =
  let Na = (0,Aa) ||> Array.scan (+)
  Ia |> Array.map (fun (l,r) -> Na.[r]-Na.[l-1])

let N,Q = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int
let Ia = Array.init Q (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N Q Aa Ia |> Array.iter stdout.WriteLine

solve 10 5 [|8;6;9;1;2;1;10;100;1000;10000|] [|(2,3);(1,4);(3,9);(6,8);(1,10)|] |> should equal [|15;24;1123;111;11137|]

@"解説記事用コード"
let Na0 = Array.create N 0
for i in 0..N-1 do
  if i=0 then Na0.[i] <- Aa.[i]
  else Na0.[i] <- Aa.[i]+Na0.[i-1]
let Na0 =
  (Array.zeroCreate N, [|0..N-1|])
  ||> Array.fold (fun Na0 i ->
    if i=0 then Na0.[i] <- Aa.[i]; Na0
    else Na0.[i] <- Aa.[i]+Na0.[i-1]; Na0)

(Array.zeroCreate N, [|0..N-1|])
||> Array.fold (fun Na0 i ->
  if i=0 then Na0.[i] <- Aa.[i]; Na0
  else Na0.[i] <- Aa.[i]+Na0.[i-1]; Na0)
|> should equal [|8; 14; 23; 24; 26; 27; 37; 137; 1137; 11137|]

(0,Aa) ||> Array.scan (+) |> should equal [|0; 8; 14; 23; 24; 26; 27; 37; 137; 1137; 11137|]

(Array.head Aa, Array.tail Aa) ||> Array.scan (+)
