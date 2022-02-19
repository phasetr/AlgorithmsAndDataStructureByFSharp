@"https://atcoder.jp/contests/abc107/tasks/abc107_b
1 \leq H, W \leq 100
a_{i, j} は . または # である。
マス目全体で少なくともひとつは黒いマスが存在する。"
#r "nuget: FsUnit"
open FsUnit

@"白(.)だけの行をfilterで消し,
転置してさらに白だけの行を消す.
最後に転置してもとの配列に戻す."
let solve H W As =
    let transpose xa =
        let rnum = Array.length xa
        let cnum = String.length xa.[0]
        let rowstr i = [|0..(rnum-1)|] |> Array.map (fun j -> Seq.item i xa.[j] |> string) |> String.concat ""
        [|0..(cnum-1)|] |> Array.map (fun i -> rowstr i)
    let Bs = As |> Array.filter (fun r -> r <> String.replicate W ".")
    Bs |> transpose
    |> Array.filter (fun r -> r <> String.replicate (String.length r) ".")
    |> transpose

let H, W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let As = [| for i in 1..H do stdin.ReadLine() |]
solve H W As |> String.concat "\n" |> stdout.WriteLine

solve 4 4 [|"##.#";"....";"##.#";".#.#"|] |> should equal [|"###";"###";".##"|]
solve 3 3 [|"#..";".#.";"..#"|] |> should equal [|"#..";".#.";"..#"|]
solve 4 5 [|".....";".....";"..#..";"....."|] |> should equal [|"#"|]
solve 7 6 [|"......";"....#.";".#....";"..#...";"..#...";"......";".#..#."|] |> should equal [|"..#";"#..";".#.";".#.";"#.#"|]
