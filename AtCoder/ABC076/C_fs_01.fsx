// https://atcoder.jp/contests/abc076/submissions/24588917
let S = stdin.ReadLine()
let T = stdin.ReadLine()

let mutable (ans: string list) = []

for i in 0..(S.Length - T.Length) do
    let mutable temp = S.ToCharArray()
    let mutable b = true
    for j in 0..T.Length - 1 do
        if not (S.[i+j] = '?' || S.[i+j] = T.[j])
        then
            b <- false
        else
            temp.[i+j] <- T.[j]
    if b
    then
        temp
        |> Array.map (fun x -> if x = '?' then 'a' else x)
        |> fun x -> new string(x)
        |> fun x -> ans <- x :: ans

if ans.Length = 0 then "UNRESTORABLE"
else
    ans
    |> List.sort
    |> List.head
|> printfn "%s"
