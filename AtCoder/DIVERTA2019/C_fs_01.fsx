// https://atcoder.jp/contests/diverta2019/submissions/24749065
let N = stdin.ReadLine() |> int
let s = [|for i in 1..N -> stdin.ReadLine()|]

let mutable ans = 0
let mutable ACount = 0
let mutable BCount = 0
let mutable ABCount = 0

for i in s do
    for j in 0..i.Length-2 do
        if i.[j..j+1] = "AB" then
            ans <- 1 + ans
    if i.[i.Length - 1] = 'A' && i.[0] = 'B' then
        ABCount <- 1 + ABCount
    elif i.[i.Length - 1] = 'A' then
        ACount <- ACount + 1
    elif i.[0] = 'B' then
        BCount <- BCount + 1

if ABCount > 0 && (ACount <> 0 || BCount <> 0) then
    ACount <- ACount+1
    BCount <- BCount+1

max (ABCount - 1) 0
|> fun x -> ans + x + (min ACount BCount)
|> printfn "%d"
