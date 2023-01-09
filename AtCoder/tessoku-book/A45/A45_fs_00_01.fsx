#r "nuget: FsUnit"
open FsUnit

(*
let N,C,S = 4,'B',"WBBR"
*)
let solve N C S =
  let f c = match c with | 'W' -> 0 | 'R' -> 1 | _ -> 2
  S |> Seq.sumBy f |> fun n -> if n%3 = f C then "Yes" else "No"

let N,C = stdin.ReadLine().Split() |> fun x -> int x.[0], char x.[1]
let S = stdin.ReadLine()
solve N C S |> stdout.WriteLine

solve 4 'B' "WBBR" |> should equal "Yes"
