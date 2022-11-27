#r "nuget: FsUnit"
open FsUnit

// let N = 575
// let N = 3600
@"TLE, Stack overflow"
let solve N =
  let rec f acc k a b c =
    if k>N then acc
    else
      acc
      + (if a&&b&&c then 1 else 0)
      + f acc (k*10+3) true b c
      + f acc (k*10+5) a true c
      + f acc (k*10+7) a b true
  f 0 0 false false false

let N = stdin.ReadLine() |> int
solve N |> stdout.WriteLine

solve 575 |> should equal 4
solve 3600 |> should equal 13
solve 999999999 |> should equal 26484
