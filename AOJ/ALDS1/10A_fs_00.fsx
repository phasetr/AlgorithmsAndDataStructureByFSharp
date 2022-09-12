#r "nuget: FsUnit"
open FsUnit

let solve N =
  let rec fib a b = function
    | 0 -> a
    | n -> fib (a+b) a (n-1)
  fib 1 0 N

let N = stdin.ReadLine() |> int
solve Xa |> stdout.WriteLine

solve 3 |> should equal 3
Array.map solve [|0..13|] |> should equal [|1;1;2;3;5;8;13;21;34;55;89;144;233;377|]
