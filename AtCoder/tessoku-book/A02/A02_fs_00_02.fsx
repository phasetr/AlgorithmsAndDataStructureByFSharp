#r "nuget: FsUnit"
open FsUnit

// forのbreakがないため再帰関数で処理
let solve N X Ia =
  let rec linSearch i =
    if i = N-1 then "No"
    elif Array.get Ia i = X then "Yes"
    else linSearch (i+1)
  linSearch 0

let N,X = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = stdin.ReadLine().Split() |> Array.map int
solve N X Ia |> stdout.WriteLine

solve 5 40 [|10;20;30;40;50|] |> should equal "Yes"
solve 6 28 [|30;10;40;10;50;50|] |> should equal "No"
