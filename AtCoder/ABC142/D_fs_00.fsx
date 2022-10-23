#r "nuget: FsUnit"
open FsUnit

let A,B = 12L,18L
let A,B = 1L,2019L
let A,B = 2L,3L
let solve A B =
  let rec gcd a b = if a=0L then b elif a<b then gcd a (b-a) else gcd (a-b) b
  let rec pfrec acc i n =
    if n<=1L then acc
    else if n<(i*i) then n::acc
    else if n%i=0L then pfrec (i::acc) i (n/i)
    else pfrec acc (i+1L) n
  let pf n = pfrec [] 2L n
  gcd A B |> pf |> List.distinct |> List.length |> (+) 1

let A,B = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0],x.[1])
solve A B |> stdout.WriteLine

solve 12L 18L |> should equal 3L
solve 420L 660L |> should equal 4L
solve 1L 2019L |> should equal 1L
