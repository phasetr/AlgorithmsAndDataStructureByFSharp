#r "nuget: FsUnit"
open FsUnit

(*
let N,X,A = 5,3,"#...#"
let N,X,A = 10,5,".#.#.####."
*)
let solve N X A =
  let x = X-1
  let q = System.Collections.Generic.Queue<int>() |> fun q -> q.Enqueue(x); q
  let Aa = A |> Seq.toArray |> fun Aa -> Aa.[x] <- '@'; Aa
  while 0<q.Count do
    let w = q.Dequeue()
    if 0<=w-1 && Aa.[w-1]='.' then Aa.[w-1] <- '@'; q.Enqueue(w-1)
    if w+1<N  && Aa.[w+1]='.' then Aa.[w+1] <- '@'; q.Enqueue(w+1)
  Aa
let N,X = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let A = stdin.ReadLine()
solve N X A |> stdout.WriteLine

solve 5 3 "#...#" |> should equal "#@@@#"
// random_01
solve 10 5 ".#.#.####." |> should equal ".#.#@####."
