#r "nuget: FsUnit"
open FsUnit

(*
let N,M,Pa,Ia = 5,2,[|3;4;-1;-5;5|],[|(1,3);(2,4)|]
*)
// From C#
let solve N M (Pa:int[]) (Ia:(int*int)[]) =
  let n = N+2
  let caps = Array2D.create (n+1) (n+1) 0
  let bfr = Array.create (n+1) (-1)
  let add a b c = caps.[a,b] <- c
  let searchPath s g =
    let srch = System.Collections.Generic.Queue<int>()
    for i in 0..n do bfr.[i] <- -1
    bfr.[s] <- 0
    srch.Enqueue(s)
    let rec frec() =
      if srch.Count=0 then false
      else
        let i = srch.Dequeue()
        if i=g then true
        else
          for j in 1..n do if bfr.[j]<0 && caps.[i,j]>0 then srch.Enqueue(j); bfr.[j] <- i
          frec()
    frec()
  let updateFlow s g =
    let mutable c = 5000
    let mutable j = g
    while j<>s do
      let i = bfr.[j]
      c <- min (caps.[i,j]) c
      j <- i
    j <- g
    while j<>s do
      let i = bfr.[j]
      caps.[i,j] <- caps.[i,j] - c
      caps.[j,i] <- caps.[j,i] + c
      j <- i
    c
  let maxFlow s g =
    let mutable ttl = 0
    while (searchPath s g) do
      ttl <- ttl + updateFlow s g
    ttl

  let hugeNum = 1000000
  let st = N+1
  let tm = N+2
  let mutable ttl = 0

  for i in 1..N do
    let p = Pa.[i-1]
    let mutable sc,tc = 0,0
    if 0<=p then tc <- p; ttl <- ttl+p else sc <- sc-p
    add st i sc
    add i tm tc

  for (a,b) in Ia do
    add b a hugeNum
  ttl - maxFlow st tm

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Pa = stdin.ReadLine().Split() |> Array.map int
let Ia = Array.init M (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N M Pa Ia |> stdout.WriteLine

solve 5 2 [|3;4;-1;-5;5|] [|(1,3);(2,4)|] |> should equal 7
