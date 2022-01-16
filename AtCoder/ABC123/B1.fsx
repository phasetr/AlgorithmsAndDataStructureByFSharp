@"問題文
AtCoder 料理店では、以下の 5 つの料理が提供されています。
ここで、「調理時間」は料理を注文してから客に届くまでの時間とします。

ABC 丼： 調理時間 A 分
ARC カレー： 調理時間 B 分
AGC パスタ： 調理時間 C 分
APC ラーメン： 調理時間 D 分
ATC ハンバーグ： 調理時間 E 分

また、この店には以下のような「注文のルール」があります。
注文は、10 の倍数の時刻 (時刻 0,10,20,30,...) にしかできない。
一回の注文につき一つの料理しか注文できない。
ある料理を注文したら、それが届くまで別の注文ができない。
ただし、料理が届いたちょうどの時刻には注文ができる。

E869120 君は時刻 0 に料理店に着きました。
彼は 5 つの料理全てを注文します。
最後の料理が届く最も早い時刻を求めてください。
ただし、料理を注文する順番は自由であり、
時刻 0 に注文することも可能とであるとします。

制約
A,B,C,D,E は 1 以上 123 以下の整数
入力
入力は以下の形式で標準入力から与えられる。"
#r "nuget: FsUnit"
open FsUnit

let getMinForZero xs =
    xs |> Array.mapi (fun i x -> (i,x))
    |> Array.filter (fun (_,x) -> x%10 <> 0)
    |> Array.reduce (fun (i,x) (j,y) -> if x%10 < y%10 then (i,x) else (j,y))
let oneceil x = (x+9) / 10 * 10
let solve A B C D E =
    let xs = [|A; B; C; D; E|]
    let ys = xs |> Array.filter (fun x -> x%10 <> 0)
    if Array.isEmpty ys then Array.sum xs
    else
       let rem = getMinForZero xs
       xs |> Array.mapi (fun i x -> if i = fst rem then snd rem else oneceil x)
       |> Array.reduce (+)

let A = stdin.ReadLine() |> int
let B = stdin.ReadLine() |> int
let C = stdin.ReadLine() |> int
let D = stdin.ReadLine() |> int
let E = stdin.ReadLine() |> int
solve A B C D E |> printfn "%d"

solve 29 20 7 35 120 |> should equal 215
solve 101 86 119 108 57 |> should equal 481
solve 123 123 123 123 123 |> should equal 643
solve 10 10 10 10 10 |> should equal 50
