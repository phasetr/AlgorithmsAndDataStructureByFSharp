// https://atcoder.jp/contests/nikkei2019-2-qual/submissions/8362408
let n = stdin.ReadLine() |> int
let ds = stdin.ReadLine().Split() |> Array.map int
let modu = 998244353L

let sPown (x:int64) y = [1..y] |>  Seq.fold (fun total _ -> total * x % modu) 1L

if ds.[0]<>0 then
    0L
else
    let countbyArray = ds.[1..] |> Array.countBy(fun x -> x) |> Array.sort
    if countbyArray.Length <> (countbyArray|> Array.last |> fst) then
        0L
    else
    countbyArray
    |> Seq.map (snd >> int64) |> Seq.fold (fun (before,total) x ->
        (x, total * (sPown before (int x)) % modu )) (1L,1L)
    |> snd
|> stdout.WriteLine
