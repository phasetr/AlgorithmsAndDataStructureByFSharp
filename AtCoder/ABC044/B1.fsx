@"w を、英小文字のみからなる文字列とします。
w が以下の条件を満たすならば、w を美しい文字列と呼ぶことにします。

どの英小文字も、w 中に偶数回出現する。
文字列 w が与えられます。w が美しい文字列かどうか判定してください。

制約
1≤w≤100
w は英小文字 (a-z) のみからなる文字列である"
#r "nuget: FsUnit"
open FsUnit

let solve w =
    w |> Array.ofSeq
    |> Array.groupBy id
    |> Array.forall (fun x -> (snd x).Length%2 = 0)
    |> fun x -> if x then "Yes" else "No"

let w = stdin.ReadLine()
solve w |> printfn "%s"

solve "abaccaba" |> should equal "Yes"
solve "hthth" |> should equal "No"
