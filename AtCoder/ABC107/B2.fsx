@"https://atcoder.jp/contests/abc107/submissions/17558435
1 \leq H, W \leq 100
a_{i, j} は . または # である。
マス目全体で少なくともひとつは黒いマスが存在する。"
#r "nuget: FsUnit"
open FsUnit

@"黒いマスが含まれる行および列をマークする.
そのあとマークされた行とマークされた列が交差する位置のa{i,j}だけを出力する."
let solve H W (As: char[,]) =
    let rows =
        [|0..(H-1)|]
        |> Array.filter (fun i -> As.[i,0..] |> Array.contains '#')
    let cols =
        [|0..(W-1)|]
        |> Array.filter (fun j -> As.[0..,j] |> Array.contains '#')
    rows
    |> Array.map (fun i ->
        cols |> Array.map (fun j -> As.[i,j]))

let H, W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let As = array2D [| for _ in 1..H do stdin.ReadLine().ToCharArray |]
solve H W As |> String.concat "\n" |> stdout.WriteLine

solve 4 4 (array2D [['#';'#';'.';'#'];['.';'.';'.';'.'];['#';'#';'.';'#'];['.';'#';'.';'#']]) |> should equal [|"###";"###";".##"|]
solve 3 3 (array2D [['#';'.';'.'];['.';'#';'.'];['.';'.';'#']]) |> should equal [|"#..";".#.";"..#"|]
solve 4 5 (array2D [['.';'.';'.';'.';'.'];['.';'.';'.';'.';'.'];['.';'.';'#';'.';'.'];['.';'.';'.';'.';'.']]) |> should equal [|"#"|]
solve 7 6 (array2D [['.';'.';'.';'.';'.';'.'];['.';'.';'.';'.';'#';'.'];['.';'#';'.';'.';'.';'.'];['.';'.';'#';'.';'.';'.'];['.';'.';'#';'.';'.';'.'];['.';'.';'.';'.';'.';'.'];['.';'#';'.';'.';'#';'.']]) |> should equal [|"..#";"#..";".#.";".#.";"#.#"|]
