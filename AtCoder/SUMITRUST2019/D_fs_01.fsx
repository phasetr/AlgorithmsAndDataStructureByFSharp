// https://atcoder.jp/contests/sumitrust2019/submissions/35041843
let fn (f: string -> int): string -> int =
  fun s ->
    [0..(s.Length - 1)]
    |> Seq.fold (fun m i ->
      match Map.tryFind s.[i] m with
      | Some _ -> m
      | _ -> m.Add (s.[i], s.[(i + 1)..] |> f)
    ) Map.empty
    |> Seq.sumBy (fun x -> x.Value)

stdin.ReadLine() |> ignore
stdin.ReadLine() |> (fn (fn (Seq.distinct >> Seq.length))) |> stdout.WriteLine
