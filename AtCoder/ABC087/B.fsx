// https://atcoder.jp/contests/abc087/tasks/abc087_b
// https://qiita.com/kuuso1/items/606b75c172cafa1d07f6
open System

#nowarn "25"
let [ a500Test; b100Test; c50Test; xTest ] = [ 4; 2; 3; 1250 ]

let fb a500 b100 c50 x =
    seq {
        for a in [ 0 .. a500 ] do
            for b in [ 0 .. b100 ] do
                for c in [ 0 .. c50 ] do
                    yield a * 500 + b * 100 + c * 50
    }
    |> Seq.sumBy (fun sum -> if sum = x then 1 else 0)

fb a500Test b100Test c50Test xTest |> printfn "%d"

let main =
    let readInt () = stdin.ReadLine() |> int
    let a500 = readInt ()
    let b100 = readInt ()
    let c50 = readInt ()
    let x = readInt ()
    fb a500 b100 c50 x |> printfn "%d"
