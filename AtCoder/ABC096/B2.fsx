@"https://atcoder.jp/contests/abc096/submissions/17333390"
#r "nuget: FsUnit"
open FsUnit

let solve H W Ss =
    let s = Ss |> Array.map Seq.toArray
    let rec f i j =
        let canDraw = s.[i].[j] = '#'
                        && s.[i+1].[j] = '.'
                        && s.[i].[j+1] = '.'
                        && (if i=0 then true else s.[i-1].[j] = '.')
                        && (if j=0 then true else s.[i].[j-1] = '.')
        if i > H-3 then true
        elif canDraw then false
        else f (if j > W-3 then i+1 else i) (if j > W-3 then 0 else j+1)
    if f 0 0 then "Yes" else "No"

let H, W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Ss = [| for i in 1..H do stdin.ReadLine() |]
solve H W Ss |> stdout.WriteLine

solve 3 3 [|".#.";"###";".#."|] |> should equal "Yes"
solve 5 5 [|"#.#.#";".#.#.";"#.#.#";".#.#.";"#.#.#"|] |> should equal "No"
solve 11 11 [|"...#####...";".##.....##.";"#..##.##..#";"#..##.##..#";"#.........#";"#...###...#";".#########.";".#.#.#.#.#.";"##.#.#.#.##";"..##.#.##..";".##..#..##.";|] |> should equal "Yes"
