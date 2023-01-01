#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa = 6,[|2;3;1;6;4;5|]
let N,Aa = 10,[|1;1;1;1;1;1;1;1;1;1|]
*)
let solve N Aa =
  let bisectLeft x (Xa:'a[]) =
    let rec bsearch l r =
      if r<=l then l
      else let m = l+(r-l)/2 in if Xa.[m] < x then bsearch (m+1) r else bsearch l m
    Xa |> Array.length |> bsearch 0

  ((0, Array.create (N+1) System.Int32.MaxValue), Aa)
  ||> Array.fold (fun (acc, dp) a ->
    let i = dp |> bisectLeft a
    dp.[i] <- a
    (max acc (i+1), dp))
  |> fst

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> stdout.WriteLine

solve 6 [|2;3;1;6;4;5|] |> should equal 4
solve 10 [|1;1;1;1;1;1;1;1;1;1|] |> should equal 1
