@"https://atcoder.jp/contests/agc007/submissions/13661183"
#r "nuget: FsUnit"
open FsUnit

let solve H W Aa =
    Aa |> Array.sumBy (fun s -> s |> Seq.filter (fun c -> c='#') |> Seq.length)
    |> fun x -> if x=H+W-1 then "Possible" else "Impossible"
let H,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Aa = [| for i in 1..H do stdin.ReadLine() |]
solve H W Aa |> stdout.WriteLine

solve 4 5 [|"##...";".##..";"..##.";"...##"|] |> should equal "Possible"
solve 5 3 [|"###";"..#";"###";"#..";"###"|] |> should equal "Impossible"
solve 4 5 [|"##...";".###.";".###.";"...##"|] |> should equal "Impossible"
