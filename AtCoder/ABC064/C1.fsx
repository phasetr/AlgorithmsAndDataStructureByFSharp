@"https://atcoder.jp/contests/abc064/tasks/abc064_c"
#r "nuget: FsUnit"
open FsUnit

type Rate = | Gray | Brown | Green | LightBlue | Blue | Yellow | Orange | Red | Any

let rate a =
    if a <= 399 then Gray
    elif a <= 799 then Brown
    elif a <= 1199 then Green
    elif a <= 1599 then LightBlue
    elif a <= 1999 then Blue
    elif a <= 2399 then Yellow
    elif a <= 2799 then Orange
    elif a <= 3199 then Red
    else Any

@"Anyは既存の色と被ってもよい.
ただし全てAnyの場合は特別な処理が必要:
最小は全て同じ色にし,
最大は全て違う色にする."
let solve N As =
    Array.map rate As
    |> Array.groupBy id
    |> Array.fold (fun (m, M) (x, arr) ->
        match x with
        | Any -> (m, M + (arr |> Array.length))
        | _ -> (m + 1, M + 1))
        (0, 0)
    |> fun (m, M) -> if m=0 then (1,M) else (m,M)

let N = stdin.ReadLine() |> int
let As = stdin.ReadLine().Split() |> Array.map int
solve N As |> fun (m,M) -> printfn "%A %A" m M

solve 4 [|2100;2500;2700;2700|] |> should equal (2,2)
solve 5 [|1100;1900;2800;3200;3200|] |> should equal (3,5)
solve 20 [|800;810;820;830;840;850;860;870;880;890;900;910;920;930;940;950;960;970;980;990|] |> should equal (1,1)
