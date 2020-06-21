(*
https://qiita.com/kuuso1/items/606b75c172cafa1d07f6#%E7%AC%AC-8-%E5%95%8F-abc-085-c---otoshidama
これのコピペ（を少し修正）
*)
#nowarn "25"
open System

let [| n; y |] =
    stdin.ReadLine().Split(' ') |> Array.map int

seq {
    for i in [ 0 .. n ] do
        for j in [ 0 .. (n - i) ] do
            yield (i, j, n - i - j)
}
|> Seq.tryFind (fun (a, b, c) -> a * 10000 + b * 5000 + c * 1000 = y)
|> (fun opt -> if Option.isSome opt then Option.get opt else (-1, -1, -1))
|> fun (a, b, c) -> printfn "%d %d %d" a b c
