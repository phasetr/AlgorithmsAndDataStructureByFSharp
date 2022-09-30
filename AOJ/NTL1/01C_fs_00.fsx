#r "nuget: FsUnit"
open FsUnit

let solve N Aa =
  let gcd m n =
    let rec frec x y = if y <= 0 then x else frec y (x%y)
    frec (max m n) (min m n)
  let lcm m n = m*n / (gcd m n)
  Array.reduce lcm Aa

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> stdout.WriteLine

solve 3 [|3;4;6|] |> should equal 12
solve 4 [|1;2;3;5|] |> should equal 30
