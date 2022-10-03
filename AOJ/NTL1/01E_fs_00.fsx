#r "nuget: FsUnit"
open FsUnit

let solve a b =
  let rec ($) a b = if b=0 then (1,0) else let(x,y) = b$(a%b) in (y,x-a/b*y)
  a $ b

let A,B = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
solve A B |> fun (x,y) -> $"{x} {y}" |> stdout.WriteLine

solve 4 12 |> should equal (1,0)
solve 3 8  |> should equal (3,-1)
