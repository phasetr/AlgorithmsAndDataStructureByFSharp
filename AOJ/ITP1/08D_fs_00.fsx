#r "nuget: FsUnit"
open FsUnit

let solve (S:string) (P:string) = S+S |> (fun s -> if s.IndexOf(P) = -1 then "No" else "Yes")

let S = stdin.ReadLine()
let P = stdin.ReadLine()
solve S P |> stdout.WriteLine

solve "vanceknowledgetoad" "advance" |> should equal "Yes"
solve "vanceknowledgetoad" "advanced" |> should equal "No"
