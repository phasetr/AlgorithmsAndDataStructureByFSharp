// https://atcoder.jp/contests/abc147/submissions/23654290
let N = stdin.ReadLine() |> int

let patern = (1 <<< N) - 1

let syougenn =
    [|for i in 1 .. N ->
        let num = stdin.ReadLine() |> int
        [|for j in 1 .. num -> stdin.ReadLine().Split() |> Array.map int|]|]


let mutable ans = 0
for i in 0..patern do
    let mutable syoujiki = 0
    let mutable mujun = true
    for j in 0..(N-1) do
        let person = i >>> j &&& 1
        syoujiki <- syoujiki + person
        if person = 1 then
            for k in syougenn.[j] do
                let p = k.[0] - 1
                mujun <- mujun && k.[1] = (i >>> p &&& 1)
    ans <- max ans (if mujun then syoujiki else 0)

printfn "%d" ans
