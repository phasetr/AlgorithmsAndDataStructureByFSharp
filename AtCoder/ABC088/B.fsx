// https://qiita.com/kuuso1/items/606b75c172cafa1d07f6
// https://atcoder.jp/contests/abc088/tasks/abc088_b

let bind x =
    match x with
    | Some a -> a
    | None -> 0

let helper a b =
    if a < b then (Some b, Some a) else (Some a, Some b)

let rec pop (pairs: (int option * int option) list) (reminder: int list) =
    match reminder with
    | [] -> pairs
    | [ a ] -> (Some a, None) :: pairs
    | a :: b :: rem -> pop ((helper a b) :: pairs) rem

[ 2; 7; 4 ]
|> List.sortDescending
|> pop []
|> List.map (fun x -> (x |> fst |> bind, x |> snd |> bind))
|> List.fold (fun x y -> (fst x + fst y, snd x + snd y)) (0, 0)
|> fun x -> fst x - snd x
|> printfn "%d"

let main =
    stdin.ReadLine() |> ignore

    stdin.ReadLine().Split(' ')
    |> Array.map int
    |> Array.toList
    |> List.sortDescending
    |> pop []
    |> List.map (fun x -> (x |> fst |> bind, x |> snd |> bind))
    |> List.fold (fun x y -> (fst x + fst y, snd x + snd y)) (0, 0)
    |> fun x -> fst x - snd x
    |> printfn "%d"
