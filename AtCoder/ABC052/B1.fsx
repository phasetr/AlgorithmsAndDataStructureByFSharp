@"問題文
あなたは整数 x を持っています。
最初、x=0 です。

あなたは、長さ N の文字列 S をもらったので、
これを使って N 回の操作を行いました。 i 回目の操作では、Si =I ならば x の値を 1 増やし、
Si=D ならば x の値を 1 減らしました。

操作の途中(1 回目の操作の前、N 回目の操作の後も含む)で x がとる値の最大値を答えてください。

制約
1≦N≦100
∣S∣=N
S には、I、D 以外の文字は含まれない"
#r "nuget: FsUnit"
open System
open System.IO
open FsUnit

let rec solve N S acc m =
    match S with
    | s when Seq.isEmpty s -> m
    | _ ->
        let h = Seq.head S
        let newacc = if h = 'I' then (acc+1) else (acc-1)
        let newm = max newacc m
        solve N (Seq.tail S) newacc newm

let N = stdin.ReadLine() |> int
let S = stdin.ReadLine()
solve N S 0 0 |> printfn "%d"

solve 5 "IIDID" 0 0 |> should equal 2
solve 7 "DDIDDII" 0 0 |> should equal 0
