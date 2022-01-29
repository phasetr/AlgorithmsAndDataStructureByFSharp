@"https://atcoder.jp/contests/abc058/tasks/abc058_b
すぬけ君は新しくできたプログラミングコンテストに会員登録しました。
登録に使ったパスワードを覚えておく自信が無かったすぬけ君は、
手元の紙にパスワードをメモしておくことにしました。
ただし、そのままメモをすると誰かにパスワードを盗まれてしまうかもしれないので、
文字列の偶数番目の文字と奇数番目の文字をそれぞれ別々の紙にメモしておくことにしました。

パスワードの奇数番目の文字だけを順番を変えずに取り出した文字列 O と、
偶数番目の文字だけを順番を変えずに取り出した文字列 E が与えられます。 すぬけ君のかわりにパスワードを復元してください。

制約
O, E は小文字のアルファベット(a - z)からなる文字列
1≤∣O∣,∣E∣≤50
∣O∣−∣E∣ は 0 または 1 である。"
#r "nuget: FsUnit"
open FsUnit

let solve O E =
    let os = List.ofSeq O
    let es = List.ofSeq E
    [0..(List.length os - 1)]
    |> List.fold (fun acc i -> (List.tryItem i es)::(List.tryItem i os)::acc) []
    |> List.choose id
    |> List.rev  |> Array.ofList |> System.String
let O = stdin.ReadLine()
let E = stdin.ReadLine()
solve O E |> stdout.WriteLine

solve "xyz" "abc" |> should equal "xaybzc"
solve "atcoderbeginnercontest" "atcoderregularcontest" |> should equal "aattccooddeerrbreeggiunlnaerrccoonntteesstt"
