// https://atcoder.jp/contests/abc084/submissions/24562440
let N = stdin.ReadLine() |> int

let station = [|for i in 2..N -> stdin.ReadLine().Split() |> Array.map int64 |]

let rec calc index (time:int64) =
    if index = N - 1 then time
    else
        if time <= station.[index].[1]
        then calc (index + 1) (station.[index].[0] + station.[index].[1])
        else
            let con = (station.[index].[2] - (time % station.[index].[2])) % station.[index].[2]
            let nt = time + station.[index].[0] + con
            calc (index + 1) (nt)

for i in 1..N do
    calc (i-1) 0L
    |> printfn "%d"
