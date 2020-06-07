(*
https://atcoder.jp/contests/abc169/tasks/abc169_c
浮動小数点数として掛け算を行うと精度が足りません。
B を 100 倍して、 (A × (B × 100))/100 とすることで、
整数の範囲で誤差なく計算することができます。
B を 100 倍して整数に変換する際にも誤差に注意してください。
はまりどころの解説 https://qiita.com/mod_poppo/items/910b5fb9303baf864bf7
*)

let cTest =
    [| [| "198"; "1.10" |]
       [| "1"; "0.01" |]
       [| "1000000000000000"; "9.99" |] |]

let fc: string [] -> int64 =
    Array.map double
    >> Array.fold (fun x y -> ((double x) * (y * 100.0)) / 100.0) 1.0
    >> floor
    >> int64

//let cAns = [| 217L; 0L; 9990000000000000L |]
cTest |> Array.map (fc >> printfn "%d")

let main =
    stdin.ReadLine().Split(' ') |> fc |> printfn "%d"
