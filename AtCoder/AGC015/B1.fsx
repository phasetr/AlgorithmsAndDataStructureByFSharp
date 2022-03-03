@"https://atcoder.jp/contests/agc015/tasks/agc015_b
2 ≦ |S| ≦ 10^5
S_i は U または D である
S_1 は U である
S_{|S|} は D である"
#r "nuget: FsUnit"
open FsUnit

@"どの階にいても最上階か一階に行ってから目的の階に行けばよく最大2回.
一回で目的階に行けるかは目的階が上か下か,
そして該当階でのボタンがUかDかによる.
各階ごとに(S-1)通りあって|S|<=10^5だからlongで計算するべき.

TLEになったのでこれは駄目: solveで書き直し."
let solveTLE (S: string) =
    let N = Seq.length S - 1
    let eachFloor i c =
        [|0..N|]
        |> Array.filter (fun j -> j <> i)
        |> Array.map (fun j ->
            match (i<j,c) with
            | (true, 'U') -> 1L
            | (true, 'D') -> 2L
            | (false, 'U') -> 2L
            | _ -> 1L)
        |> Array.sum
    [|0..N|] |> Array.map (fun i -> eachFloor i S.[i])
    |> Array.sum

@"i階が`U`なら上の階は1回, 下の階は2回.
i階が`D`なら上の階は2回, 下の階は1回.
ある階より上/下にある階の個数は簡単に求められる."
let solve (S: string) =
    let N = Seq.length S
    S |> Seq.mapi (fun i c ->
        let j = i+1
        (if c='U' then (N-j) + 2*(j-1) else 2*(N-j) + (j-1)) |> int64)
    |> Seq.sum
let S = stdin.ReadLine()
solve S |> stdout.WriteLine

solve "UUD" |> should equal 7L
solve "UUDUUDUD" |> should equal 77L
