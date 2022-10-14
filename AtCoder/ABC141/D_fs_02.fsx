// https://atcoder.jp/contests/abc141/submissions/7942120
let [| n; m; |] = stdin.ReadLine().Split() |> Array.map int
let a = stdin.ReadLine().Split() |> Array.map int64

let sortedSet = a |> Array.mapi (fun i x -> x, i+1) |> Set.ofArray

seq{1..m} |> Seq.fold (fun (set:Set<int64*int>) _ ->
    set |> Set.remove (set.MaximumElement) |> Set.add (set.MaximumElement |> fun (x,i) ->(x/2L, i))) sortedSet
|> Seq.sumBy (fun (x,_) -> x)
|> stdout.WriteLine
