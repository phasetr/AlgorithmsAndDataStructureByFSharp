#r "nuget: FsUnit"
open FsUnit

let N,S = 3,"#.#"
let N,S = 5,"#.##."
let N,S = 9,"........."
let solveTLE N (S:string) =
  let count i = (S.[0..i-1] |> Seq.filter ((=)'#') |> Seq.length) + (S.[i..] |> Seq.filter ((=)'.') |> Seq.length)
  [|0..N|] |> Array.map count |> Array.min

let solve N (S:string) =
  let b = (0,S) ||> Seq.scan (fun acc c -> if c='#' then acc+1 else acc)
  let a = (S,0) ||> Seq.scanBack (fun c acc -> if c='.' then acc+1 else acc)
  Seq.map2 (+) a b |> Seq.min

let N = stdin.ReadLine() |> int
let S = stdin.ReadLine()
solve N S |> stdout.WriteLine

solve 3 "#.#" |> should equal 1
solve 5 "#.##." |> should equal 2
solve 9 "........." |> should equal 0
solve 3 "#.." |> should equal 1
solve 3 ".#." |> should equal 1
solve 4 ".#.." |> should equal 1
