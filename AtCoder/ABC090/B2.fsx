@"https://atcoder.jp/contests/abc090/submissions/2234698"
#r "nuget: FsUnit"
open FsUnit

let ispal x =
    let s = x |> string |> fun y -> y.ToCharArray()
    s = (Array.rev s)

let solve A B = [|A..B|] |> Array.filter ispal |> Array.length
let A, B = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
solve A B |> printfn "%d"

ispal "11009" |> should equal false
ispal "11011" |> should equal true
ispal "12012" |> should equal false
ispal "12021" |> should equal true
solve 11009 11332 |> should equal 4
solve 31415 92653 |> should equal 612
