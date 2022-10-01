#r "nuget: FsUnit"
open FsUnit

let solve N =
  let primeFactors n =
    let rec frec i x acc =
      if i*i > n then if x=1 then acc else x :: acc
      else if x%i = 0 then frec i (x/i) (i :: acc)
      else frec (i+1) x acc
    frec 2 n []

  primeFactors N
  |> List.countBy id
  |> List.fold (fun acc (p,e) -> acc * (pown p e - pown p (e-1))) 1

let N = stdin.ReadLine() |> int
solve N |> stdout.WriteLine

solve 6 |> should equal 2
solve 1000000 |> should equal 400000
