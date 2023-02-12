#r "nuget: FsUnit"
open FsUnit

(*
let S,T = "tokyo","Kyoto"
let S,T = "competitive","programming"
let S,T = "abcdef","bdf"
*)
let solve S T =
  let sLen = S |> String.length
  let tLen = T |> String.length
  (Array.init (tLen+1) id, [|1..sLen|]) ||> Array.fold (fun prev i ->
    let cur = Array.create (tLen+1) i
    for j in 1..tLen do
      let cost = if S.[i-1]=T.[j-1] then 0 else 1
      cur.[j] <- min (min (prev.[j]+1) (cur.[j-1]+1)) (prev.[j-1]+cost)
    cur)
  |> Array.last
let S = stdin.ReadLine()
let T = stdin.ReadLine()
solve S T |> stdout.WriteLine

solve "tokyo" "Kyoto" |> should equal 4
solve "competitive" "programming" |> should equal 10
solve "abcdef" "bdf" |> should equal 3
