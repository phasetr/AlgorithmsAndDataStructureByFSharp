@"https://atcoder.jp/contests/abc065/submissions/13487268"
#r "nuget: FsUnit"
open FsUnit

@"TLEするが最後のテストは通る.
Haskellなら通るか?"
let solve N As =
    let f = function
        | Some x -> x
        | None -> -1
    As
    |> Seq.scan (fun acc _ -> Seq.item (acc-1) As) 1
    |> Seq.take N
    |> Seq.tryFindIndex (fun i -> i=2)
    |> fun x -> if Option.isSome x then Option.get x else -1

let N = stdin.ReadLine() |> int
let As = [| for i in 1..N do (stdin.ReadLine() |> int) |]
solve N As |> stdout.WriteLine

solve 3 [|3;1;2|] |> should equal 2
solve 4 [|3;4;1;2|] |> should equal -1
solve 5 [|3;3;4;2;4|] |> should equal 3
