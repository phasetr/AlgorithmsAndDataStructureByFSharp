#r "nuget: FsUnit"
open FsUnit

let N,Aa = 4,[|(2,4);(4,3);(9,3);(100,5)|]
let N,Aa = 2,[|(8,20);(1,10)|]
let N,Aa = 5,[|(10,1);(2,1);(4,1);(6,1);(8,1)|]
let solve N Aa =
  let Ba = Aa |> Array.map (fun (x,l) -> (x-l,x+l)) |> Array.sort |> List.ofArray
  let rec remove k (l1,r1) = function
    | [] -> k
    | ((l2,r2) as h2)::hs ->
      if r1<=l2 then remove (k+1) (l2,r2) hs
      else if l2<r1 && r1<=r2 then remove k (l1,r1) hs
      else remove k (l2,r2) hs
  remove 1 (List.head Ba) (List.tail Ba)

let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do (stdin.ReadLine().Split() |> fun x -> (int x.[0], int x.[1])) |]
solve N Aa |> stdout.WriteLine

solve 4 [|(2,4);(4,3);(9,3);(100,5)|] |> should equal 3
solve 2 [|(8,20);(1,10)|] |> should equal 1
solve 5 [|(10,1);(2,1);(4,1);(6,1);(8,1)|] |> should equal 5
