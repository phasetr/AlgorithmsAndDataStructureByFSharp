@"https://atcoder.jp/contests/abc058/submissions/17232345"
#r "nuget: FsUnit"
open FsUnit

let solve (O: string) (E: string) =
    let os = O.ToCharArray()
    let es = E.ToCharArray()
    if os.Length = es.Length then Array.zip os es
    else Array.zip os (Array.append es [|' '|])
    |> Array.collect (fun (os,es) -> [|os;es|])
    |> System.String
    |> fun os -> os.Trim()
let O = stdin.ReadLine()
let E = stdin.ReadLine()
solve O E |> stdout.WriteLine

solve "xyz" "abc" |> should equal "xaybzc"
solve "atcoderbeginnercontest" "atcoderregularcontest" |> should equal "aattccooddeerrbreeggiunlnaerrccoonntteesstt"
