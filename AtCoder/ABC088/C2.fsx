@"https://atcoder.jp/contests/abc088/submissions/17424548"
#r "nuget: FsUnit"
open FsUnit

let solve Xs =
    let validate a1 a2 =
        (a1, a2)
        ||> Array.map2 (-)
        |> fun x -> x.[1..] |> Array.forall (fun y -> y = x.[0])
    if validate c.[0] c.[1] && validate c.[0] c.[2]
    then "Yes" else "No"

let ca = [| for i in 1..3 do (stdin.ReadLine().Split() |> Array.map int) |]
solve ca |> stdout.WriteLine

solve [|[|1;0;1|];[|2;1;2|];[|1;0;1|]|] |> should equal "Yes"
solve [|[|2;2;2|];[|2;1;2|];[|2;2;2|]|] |> should equal "No"
solve [|[|0;8;8|];[|0;8;8|];[|0;8;8|]|] |> should equal "Yes"
solve [|[|1;8;6|];[|2;9;7|];[|0;7;7|]|] |> should equal "No"
