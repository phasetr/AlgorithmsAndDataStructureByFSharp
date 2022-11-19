// https://atcoder.jp/contests/abc079/submissions/23187308
(
  (stdin.ReadLine().Split() |> fun x -> int x.[0]),
  (Array.init 10 (fun _ -> stdin.ReadLine().Split() |> Array.map int))
)
|> fun (h, costs) ->
  seq {
    for k in 0..9 do
    for i in 0..9 do
    for j in 0..9 do
    yield (i, j, k)
  }
  |> Seq.iter (fun (i, j, k) ->
    costs.[i].[j] <- min costs.[i].[j] (costs.[i].[k] + costs.[k].[j])
  )
  |> fun _ ->
    seq { 1..h }
    |> Seq.map(fun _ ->
      stdin.ReadLine().Split()
      |> Array.map int
      |> Array.sumBy(fun x -> if x = -1 then 0 else costs.[x].[1])
    )
    |> Seq.sum
|> printfn "%d"
