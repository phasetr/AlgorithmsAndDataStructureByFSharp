#r "nuget: FsUnit"
open FsUnit

let S,T = "?tc????","coder"
let S,T = "??p??d??","abc"
let S,T = "?????","z"
let S,T = "???z?","z"
// cf. https://atcoder.jp/contests/abc076/submissions/9944686
let solve (S:string) (T:string) =
  let sl = String.length S
  let tl = String.length T
  let rec f = function
    | [] -> true
    | x::xs -> let a,b = x in not (a<>'?' && a <> b) && f xs
  [|0..sl-tl|]
  |> Array.filter (fun i -> Seq.zip (Seq.skip i S |> Seq.take tl) T |> Seq.toList |> f)
  |> Array.map (fun i -> S.[0..i-1] + T + S.[i+tl..] |> String.map (fun c -> if c='?' then 'a' else c))
  |> fun a -> if Array.isEmpty a then "UNRESTORABLE" else Array.min a

let S = stdin.ReadLine()
let T = stdin.ReadLine()
solve S T |> stdout.WriteLine

solve "?tc????" "coder" |> should equal "atcoder"
solve "??p??d??" "abc" |> should equal "UNRESTORABLE"
solve "?????" "z" |> should equal "aaaaz"
solve "???z?" "z" |> should equal "aaaza"
