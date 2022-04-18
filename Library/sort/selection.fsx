#r "nuget: FsUnit"
open FsUnit

@"https://onlinejudge.u-aizu.ac.jp/problems/ALDS1_2_B
../../AOJ/ALDS1/02B01.hs"
module Selection1 =
    let minIndex xs =
        let m = List.min xs
        List.findIndex ((=) m) xs
    minIndex [1..5] |> should equal 0
    minIndex [2;1;3] |> should equal 1
    minIndex [3;2;1] |> should equal 2

    let swap xs minj =
        if minj>0 then
            let (ys,zs) = List.splitAt minj xs
            (List.head zs)::(List.tail ys)@(List.head ys)::(List.tail zs)
        else xs

    let ssort xs =
        let n = List.length xs - 2
        let f xs i =
            let (ys,zs) = List.splitAt i xs
            let ws = swap zs (minIndex zs)
            ys@ws
        List.fold f xs [0..n]
    ssort [7;3;2;1;4;5] |> should equal [1;2;3;4;5;7]

module SelectionWithStep =
    let minIndex xs =
        let m = List.min xs
        List.findIndex ((=) m) xs

    let swap xs minj =
        if minj>0 then
            let (ys,zs) = List.splitAt minj xs
            (List.head zs)::(List.tail ys)@(List.head ys)::(List.tail zs)
        else xs

    let ssort (xs:list<int>) =
        let n = List.length xs - 2
        let f (xss:list<list<int>>) i =
            let (ys,zs) = List.splitAt i xss.[0]
            let ws = swap zs (minIndex zs)
            (ys@ws)::xss
        List.fold f [xs] [0..n]
    ssort [7;3;2;1;4;5] |> List.rev |> List.iter (printfn "%A")

// https://qiita.com/Tatsuki-I/items/66d1f5186348aaa9b537
module SelectionByUnfold =
    let deleteAll x = List.filter ((<>) x)
    let sepMin = function
        | [] -> None
        | xs ->
            let y = List.min xs
            let ys = deleteAll y xs
            Some(y, ys)
    let ssort xs = List.unfold sepMin xs
    ssort [7;3;2;1;4;5] |> should equal [1;2;3;4;5;7]
