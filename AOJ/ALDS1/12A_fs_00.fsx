#r "nuget: FsUnit"
open FsUnit

let solve N (Aa: int[][]) =
  let maxInt = System.Int32.MaxValue
  let mutable minCosts = Array.create N System.Int32.MaxValue
  minCosts.[0] <- 0
  let mutable reachedP = Array.create N false
  let rec frec () =
    let u =
      ((0, maxInt, (-1)), minCosts)
      ||> Array.fold (fun (i,m,u) e -> if not reachedP.[i] && m > e then (i+1, e, i) else (i+1, m, u))
      |> (fun (_, _, u) -> u)
    if u = (-1) then ()
    else
      reachedP.[u] <- true
      for j = 0 to N-1 do
        if Aa.[u].[j] <> (-1) && not reachedP.[j] && minCosts.[j] > Aa.[u].[j]
        then minCosts.[j] <- Aa.[u].[j]
      done
      frec ()
  frec ();
  (0,minCosts) ||> Array.fold (fun sum c -> if c = maxInt then sum else sum + c)

let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do (stdin.ReadLine().Split() |> Array.map int) |]
solve N Aa |> stdout.WriteLine

let N,Aa = 5,[|[|-1;2;3;1;-1|];[|2;-1;-1;4;-1|];[|3;-1;-1;1;1|];[|1;4;1;-1;3|];[|-1;-1;1;3;-1|]|]
solve N Aa |> should equal 5
