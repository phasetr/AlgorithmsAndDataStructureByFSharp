@"https://atcoder.jp/contests/abc079/tasks/abc079_c"
#r "nuget: FsUnit"
open FsUnit

let solve Xs =
    let f x (accsum, s) =
        [(accsum+x, $"{s}+{x}");(accsum-x, $"{s}-{x}")]
    let rec g acc = function
        | [] -> acc
        | x::xs ->
            match acc with
            | [] -> g [(x, $"{x}")] xs
            | ys ->
                let zs = ys |> List.collect (f x)//List.collect (fun (accsum, s) -> [(accsum+y, $"{s}+{y}");(accsum-y, $"{s}-{y}")])
                g zs xs
    Xs |> Seq.map (string >> int) |> Seq.toList
    |> g []
    |> List.filter (fun (s,_) -> s = 7)
    |> List.head |> fun x -> $"{snd x}=7"

let Xs = stdin.ReadLine()
solve Xs |> stdout.WriteLine

solve "1222" |> should equal "1+2+2+2=7"
solve "0290" |> should equal "0-2+9+0=7"
solve "3242" |> should equal "3+2+4-2=7"
