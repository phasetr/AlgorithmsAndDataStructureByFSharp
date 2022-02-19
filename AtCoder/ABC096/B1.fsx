@"https://atcoder.jp/contests/abc096/tasks/abc096_c"
#r "nuget: FsUnit"
open FsUnit

@"全ての`#`が上下左右隣りのどこかに`#`があるか調べる.
または一つでも`.`だけに囲まれた`#`があるかどうか.
上下や左右の端の処理も考える必要がある.
数が少ないので各`#`に対して個別に上下左右に`#`があるか調べよう."
let solve H W Ss =
    let tryItem i j sa = Array.tryItem i sa |> Option.map (Array.tryItem j) |> Option.flatten
    let checkEachSharp i j sa =
        [|tryItem (i-1) j sa; tryItem (i+1) j sa; tryItem i (j-1) sa; tryItem i (j+1) sa|]
        |> Array.choose id
        |> Array.fold (fun acc c -> acc || c='#') false

    let sa = Ss |> Array.map Seq.toArray
    sa |> Array.mapi (fun i s ->
        s
        |> Array.mapi (fun j e -> if e='#' then checkEachSharp i j sa else true)
        |> Array.forall id)
    |> Array.forall id
    |> fun b -> if b then "Yes" else "No"

let H, W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Ss = [| for i in 1..H do stdin.ReadLine() |]
solve H W Ss |> stdout.WriteLine

solve 3 3 [|".#.";"###";".#."|] |> should equal "Yes"
solve 5 5 [|"#.#.#";".#.#.";"#.#.#";".#.#.";"#.#.#"|] |> should equal "No"
solve 11 11 [|"...#####...";".##.....##.";"#..##.##..#";"#..##.##..#";"#.........#";"#...###...#";".#########.";".#.#.#.#.#.";"##.#.#.#.##";"..##.#.##..";".##..#..##.";|] |> should equal "Yes"
