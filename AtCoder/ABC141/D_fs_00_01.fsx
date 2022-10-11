#r "nuget: FsUnit"
open FsUnit

// TLE: 優先度つきヒープの代わりに配列を使ってみた
let N,M,Aa = 3,3,[|2L;13L;8L|]
let solve N M Aa =
  let rec frec M As =
    if M=0 then As
    else let (m,i) = Set.maxElement As in As |> Set.remove (m,i) |> Set.add (m/2L,i) |> frec (M-1)
  Array.zip Aa [|1..N|] |> Set.ofArray |> frec M |> Set.fold (fun acc (x,_) -> acc+x) 0L

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N M Aa |> stdout.WriteLine

solve 3 3 [|2L;13L;8L|] |> should equal 9L
solve 4 4 [|1L;9L;3L;5L|] |> should equal 6L
solve 1 100000 [|1000000000L|] |> should equal 0L
solve 10 1 [|1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L|] |> should equal 9500000000L
