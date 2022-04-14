@"https://atcoder.jp/contests/dp/tasks/dp_b"
#r "nuget: FsUnit"
open FsUnit

let N,K,Ha = 5,3,[|10;30;40;50;20|]
let solve N K (Ha:int[]) =
    let f l h = List.truncate K l |> List.map(fun (ci,hi) -> ci+abs(h-hi)) |> List.min |> fun c -> (c,h)::l
    Array.fold f [(0,Ha.[0])] Ha.[1..] |> (List.head >> fst)
let N,K = stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0], x.[1]
let Ha = stdin.ReadLine().Split() |> Array.map int
solve N K Ha |> stdout.WriteLine

solve 5 3 [|10;30;40;50;20|] |> should equal 30
solve 3 1 [|10;20;10|] |> should equal 20
solve 2 100 [|10;10|] |> should equal 0
solve 10 4 [|40;10;20;70;80;10;20;70;80;60|] |> should equal 40
