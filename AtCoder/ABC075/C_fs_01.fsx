// https://atcoder.jp/contests/abc075/submissions/28231844
(
  fun n ->
    ([| n |], [| 0..n |])
    |> fun (cnt, table) ->
      (fun x -> ([| true |]) |> fun next -> Seq.initInfinite ignore |> Seq.takeWhile (fun () -> next.[0]) |> Seq.scan (fun c _ -> table.[c] |> fun p -> if p = c then (next.[0] <- false) |> fun _ -> c else p) x |> Seq.rev |> Seq.toList)
      |> fun findTree ->
        (
          findTree >> (fun tree -> tree |> List.tail |> List.iter (fun x -> table.[x] <- tree |> Seq.head) |> fun () -> tree |> Seq.head),
          fun newRoot -> findTree >> (fun tree -> tree |> Seq.head |> fun oldRoot -> tree |> List.iter (fun x -> table.[x] <- newRoot) |> fun () -> oldRoot)
        )
        |> fun (findRoot, updateRoot) ->
          (
            (fun a b -> (findRoot a) |> fun rA -> (updateRoot rA b) |> fun rB -> if (rA <> rB) then cnt.[0] <- cnt.[0] - 1),
            fun () -> cnt.[0]
          )
)
|> fun unionFindTree ->
  (* main *)
  stdin.ReadLine().Split() |> Array.map int |> fun x -> (x.[0], x.[1])
  |> fun (n, m) ->
    [1..m] |> List.map(fun i -> stdin.ReadLine().Split() |> Array.map int |> fun x -> (i, x.[0], x.[1]))
    |> fun vs ->
      [1..m]
      |> List.map (fun i ->
        unionFindTree n |> fun (unite, count) ->
          vs |> List.filter (fun (i2, _, _) -> i <> i2) |> List.iter (fun (_, a, b) -> unite a b) |> count
      )
      |> List.filter ((<) 1)
      |> List.length
  |> printfn "%d"
