@"https://atcoder.jp/contests/abc128/tasks/abc128_c
* 1 \leq N, M \leq 10
* 1 \leq k_i \leq N
* 1 \leq s_{ij} \leq N
* s_{ia} \neq s_{ib} (a \neq b)
* p_i は 0 または 1
* 入力は全て整数である"
#r "nuget: FsUnit"
open FsUnit

let N,M,Ia,Pa = 5,2,[|[|3;1;2;5|];[|2;2;3|]|],[|1;0|]
let solve N M Ia Pa =
    let allsubs Xs =
        let rec frec = function
            | [] -> []
            | x::xs ->
                let f ys r = ys :: (x :: ys) :: r
                [x] :: List.foldBack f (frec xs) []
        [] :: frec Xs
    let isOnAt os (ss,p) =
        List.filter (fun s -> List.contains s os) ss
        |> fun xs -> (List.length xs) % 2 = p

    let sss = Array.map (fun xa -> Array.tail xa |> Array.toList) Ia |> Array.toList
    let ps = Pa |> Array.toList
    allsubs [1..N]
    |> List.choose (fun sub ->
        if List.forall (isOnAt sub) (List.zip sss ps)
        then Some 1 else None)
    |> List.length
let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Ia = [| for i in 1..M do (stdin.ReadLine().Split() |> Array.map int) |]
let Pa = stdin.ReadLine().Split() |> Array.map int
solve N M Ia Pa |> stdout.WriteLine

solve 2 2 [|[|2;1;2|];[|1;2|]|] [|0;1|] |> should equal 1
solve 2 3 [|[|2;1;2|];[|1;1|];[|1;2|]|] [|0;0;1|] |> should equal 0
solve 5 2 [|[|3;1;2;5|];[|2;2;3|]|] [|1;0|] |> should equal 8
