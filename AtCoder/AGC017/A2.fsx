@"https://atcoder.jp/contests/agc017/submissions/13677272"
#r "nuget: FsUnit"
open FsUnit

let solve N P Aa =
    Aa |> Array.filter (fun x -> x % 2 = 1) |> Array.length
    |> fun oddnum ->
        if oddnum = 0 then if P = 0 then (int64 1) <<< N else (int64 0)
        else (int64 1) <<< (N-1)

let N, P = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N P Aa |> stdout.WriteLine

solve 2 0 [|1;3|] |> should equal 2L
solve 1 1 [|50|] |> should equal 0L
solve 3 0 [|1;1;1|] |> should equal 4L
solve 45 1 [|17;55;85;55;74;20;90;67;40;70;39;89;91;50;16;24;14;43;24;66;25;9;89;71;41;16;53;13;61;15;85;72;62;67;42;26;36;66;4;87;59;91;4;25;26|] |> should equal 17592186044416L
