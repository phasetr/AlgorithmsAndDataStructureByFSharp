@"https://atcoder.jp/contests/abc075/tasks/abc075_b
1≦H,W≦50
S_i は # と . からなる長さ W の文字列"
#r "nuget: FsUnit"
open FsUnit

let solve H W Ss =
    let tryItem i j xa = Array.tryItem i xa |> Option.map (Array.tryItem j) |> Option.flatten
    let checkMine i j xa =
        let a = tryItem i j xa
        match a with
        | None -> 0
        | Some (c) -> if c='#' then 1 else 0
    let f i j saa =
        [|checkMine (i-1) (j-1) saa; checkMine (i-1) j saa; checkMine (i-1) (j+1) saa;
         checkMine i (j-1) saa; checkMine i (j+1) saa;
         checkMine (i+1) (j-1) saa; checkMine (i+1) j saa; checkMine (i+1) (j+1) saa|]
        |> Array.sum |> string |> char

    let saa = Array.map Array.ofSeq Ss
    [|0..(H-1)|]
    |> Array.map (fun i ->
        saa.[i]
        |> Array.mapi (fun j c -> if c='#' then '#' else f i j saa))
    |> Array.map (fun ca -> ca |> Array.map string |> String.concat "")

let H, W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Ss = [| for i in 1..H do stdin.ReadLine() |]
solve H W Ss |> String.concat "\n" |> stdout.WriteLine

solve 3 5 [|".....";".#.#.";"....."|] |> should equal [|"11211";"1#2#1";"11211"|]
solve 3 5 [|"#####";"#####";"#####"|] |> should equal [|"#####";"#####";"#####"|]
solve 6 6 [|"#####.";"#.#.##";"####.#";".#..#.";"#.##..";"#.#..."|] |> should equal [|"#####3";"#8#7##";"####5#";"4#65#2";"#5##21";"#4#310"|]
