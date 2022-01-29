@"https://atcoder.jp/contests/abc058/submissions/17232345"
#r "nuget: FsUnit"
open FsUnit

let solve (O: string) (E: string) =
    [for i=0 to E.Length - 1 do
     O.[i].ToString() + E.[i].ToString()
     ] |> List.fold(+) ""
    |> fun x -> if O.Length > E.Length then x + O.[O.Length-1].ToString() else x

let O = stdin.ReadLine()
let E = stdin.ReadLine()
solve O E |> stdout.WriteLine

solve "xyz" "abc" |> should equal "xaybzc"
solve "atcoderbeginnercontest" "atcoderregularcontest" |> should equal "aattccooddeerrbreeggiunlnaerrccoonntteesstt"
