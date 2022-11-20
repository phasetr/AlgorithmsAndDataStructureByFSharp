// https://atcoder.jp/contests/abc084/submissions/24527356
100000
|> fun maxValue ->
  (
    [| [2] |],
    (Array.create maxValue false),
    (Array.create maxValue 0)
  )
  |> fun (ps, isPN, acc) ->
    seq {
      yield 2;
      yield!
        Seq.initInfinite (fun i -> 3 + i * 2)
        |> Seq.filter (
          fun x ->
            x
            |> (double >> sqrt >> int)
            |> fun ul -> ps.[0] |> List.forall (fun p -> ul < p || x % p <> 0)
        )
        |> Seq.map (fun x -> (ps.[0] <- x::ps.[0]) |> fun _ -> x)
    }
    |> Seq.takeWhile ((>) maxValue)
    |> Seq.iter (fun x -> isPN.[x] <- true)
    |> fun _ -> [2..maxValue - 1]
    |> Seq.fold (fun a i ->
      (i &&& 1 = 1 && isPN.[i] && isPN.[(i + 1) / 2])
      |> fun c -> (if c then a + 1 else a)
      |> fun v -> (acc.[i] <- v) |> fun _ -> v
    ) 0
    |> fun _ -> stdin.ReadLine() |> int
    |> fun q -> [1..q]
    |> Seq.map (fun i ->
      stdin.ReadLine().Split()
      |> Array.map int
      |> fun x -> (x.[0], x.[1])
      |> fun (l, r) -> acc.[r] - acc.[l - 1]
    )
|> Seq.iter (printfn "%d")
