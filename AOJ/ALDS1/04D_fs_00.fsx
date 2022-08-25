#r "nuget: FsUnit"
open FsUnit

let solve N K (Xa: int[]) =
  let rec load i j s p =
    if i=N then true
    else if j=K then false
    else if s+Xa.[i] <= p then load (i+1) j (s+Xa.[i]) p else load i (j+1) 0 p
  let rec loop left right =
    if left < right then
      let mid = (left+right)/2
      if load 0 0 0 mid then loop left mid
      else loop (mid+1) right
    else right
  let l = Array.max Xa
  let r = 100000*100000
  loop l r

let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Wa = [| for i in 1..N do (stdin.ReadLine() |> int) |]
solve N K Xa |> stdout.WriteLine

solve 5 3 [|8;1;7;3;9|] |> should equal 10
solve 4 2 [|1;2;2;6|] |> should equal 6
