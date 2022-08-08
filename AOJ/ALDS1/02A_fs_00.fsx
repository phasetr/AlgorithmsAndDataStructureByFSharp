#r "nuget: FsUnit"
open FsUnit

let solve N Xa =
  let bsort (a:int[]) n count =
    let rec f flag count = if flag then (bubble (n-1) false count) else (a, count)
    and bubble i flag count =
      if i = 0 then f flag count
      else if a.[i-1] <= a.[i] then bubble (i-1) flag count
      else
        let tmp = a.[i]
        a.[i] <- a.[i-1]
        a.[i-1] <- tmp
        bubble (i-1) true (count+1)
    f true 0
  bsort Xa N 0

let N = stdin.ReadLine() |> int
let Xa = stdin.ReadLine().Split() |> Array.map int
solve N Xa |> stdout.WriteLine

solve 5 [|5;3;2;4;1|] |> should equal ([|1;2;3;4;5|], 8)
solve 6 [|5;2;4;6;1;3|] |> should equal ([|1;2;3;4;5;6|], 9)
