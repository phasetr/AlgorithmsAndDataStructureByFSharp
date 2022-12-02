(*
let N = 2L
let N = 3485L
let N = 4664L
*)
let solve N =
  seq {
    for h in 1L..3500L do
      for k in 1L..h do
        let d = 4L*h*k-N*(k+h)
        if d>0L && (N*h*k)%d=0L then yield (h,k,(N*h*k)/d)
  } |> Seq.head |> fun (h,k,w) -> [|h;k;w|]

let N = stdin.ReadLine() |> int64
solve N |> Array.map string |> String.concat " " |> stdout.WriteLine

(*
配列変換しない場合は次の出力処理で書ける.
solve N |> fun (h,n,k) -> printfn "%d %d %d" h n k
*)

(*
solve 2L |> fun [|h;n;k|] -> 4L*h*n*k = 2L*(h*n+n*k+k*h)
solve 3485L |> fun [|h;n;k|] -> 4L*h*n*k = 3485L*(h*n+n*k+k*h)
solve 4664L |> fun [|h;n;k|] -> 4L*h*n*k = 4664L*(h*n+n*k+k*h)
*)

seq {
    for x in 1..10 do
        yield x
        yield! seq { for i in 1..x -> i}
} |> Array.ofSeq
