#r "nuget: FsUnit"
open FsUnit

(*
let N,M,Ca = 2,1,[|"111111111111000000000000";"000000000000111111111111"|]
let N,M,Ca = 10,2,[|"101001000011000100010111";"000010011110110010100111";"101110001110000011110111";"011011110100011110100011";"000011001111111010110001";"001010011010101010110100";"001010010111101101111010";"110011111100010110111011";"100010011100011101110001";"010110100101101111111011"|]
*)
let solve N M Ca =
  let dhour = 24
  let n = N + dhour + 2
  let caps = Array2D.create (n+1) (n+1) 0
  let bfr = Array.create (n+1) (-1)
  let add a b c = caps.[a,b] <- c
  let searchPath s g =
    let srch = System.Collections.Generic.Queue<int>() |> fun q -> q.Enqueue(s); q
    for i in 0..n do bfr.[i] <- -1
    bfr.[s] <- 0
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
    while j<>s do let i = bfr.[j] in c <- min (caps.[i,j]) c; j <- i
    j <- g
    while j<>s do let i = bfr.[j] in caps.[i,j] <- caps.[i,j] - c; caps.[j,i] <- caps.[j,i] + c; j <- i
    c
  let maxFlow s g =
    let mutable ttl = 0
    while searchPath s g do ttl <- ttl + updateFlow s g
    ttl

  let st = N+dhour+1
  let tm = N+dhour+2
  Ca |> Array.iteri (fun i s -> s |> String.iteri (fun j c -> if c='1' then add (i+1) (N+j+1) 1))
  for i in 1..N do add st i 10
  for i in 1..dhour do add (N+i) tm M
  if maxFlow st tm = M*dhour then "Yes" else "No"

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init N (fun _ -> stdin.ReadLine())
solve N M Ia |> stdout.WriteLine

solve 2 1 [|"111111111111000000000000";"000000000000111111111111"|] |> should equal "No"
solve 10 2 [|"101001000011000100010111";"000010011110110010100111";"101110001110000011110111";"011011110100011110100011";"000011001111111010110001";"001010011010101010110100";"001010010111101101111010";"110011111100010110111011";"100010011100011101110001";"010110100101101111111011"|] |> should equal "Yes"
