#r "nuget: FsUnit"
open FsUnit

let bsearch xa n x =
  let rec search l r =
    if r<=l then false else
      let m = (l+r)/2
      if Array.get xa m = x then true
      else if Array.get xa m < x then search (m+1) r
      else search l m
  search 0 n

let solve N Sa Ta = (0,Ta) ||> Array.fold (fun c t -> if bsearch Sa N t then c+1 else c)

let N = stdin.ReadLine() |> int
let Sa = stdin.ReadLine().Split() |> Array.map int
let Q = stdin.ReadLine() |> int
let Ta = stdin.ReadLine().Split() |> Array.map int
solve Sa Ta |> stdout.WriteLine

solve 5 [|1..5|] [|3;4;1|] |> should equal 3
solve 3 [|1..3|] [|5|] |> should equal 0
solve 5 [|1;1;2;2;3|] [|1;2|] |> should equal 2
