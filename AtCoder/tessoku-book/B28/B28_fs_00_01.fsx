#r "nuget: FsUnit"
open FsUnit

(*
let N = 6
let N = 8691200
*)
let solve N =
  let MOD = 1_000_000_007
  let (.+) a b = (a+b)%MOD
  let fib n = ((0,1), Seq.init n id) ||> Seq.fold (fun (n1,n2) items -> (n1.+n2,n1)) |> fst
  fib N
let N = stdin.ReadLine() |> int
solve N |> stdout.WriteLine

solve 6 |> should equal 8
solve 8691200 |> should equal 922041576
