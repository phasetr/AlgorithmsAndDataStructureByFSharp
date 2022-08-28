#r "nuget: FsUnit"
open FsUnit

let solve N Aa =
  let mutable cnt = 0
  let merge (a: int[]) l m r =
    let x = m - l in
    let ai = Array.create (x + 1) System.Int32.MaxValue in
    for i = 0 to x - 1 do
      ai.[i] <- a.[l+i]
    done
    let aj = Array.create (r - m + 1) System.Int32.MaxValue in
    for i = 0 to r - m - 1 do
      aj.[i] <- a.[m + i]
    done;
    let mutable i = 0
    let mutable j = 0
    for k = l to r - 1 do
      if ai.[i] <= aj.[j] then begin
          a.[k] <- ai.[i]
          i <- i+1
        end else begin
          a.[k] <- aj.[j]
          cnt <- cnt + (x - i)
          j <- j+1
        end
    done
  let rec msort a l r =
    if (l+1) >= r then () else
      let m = (l+r)/2
      msort a l m
      msort a m r
      merge a l m r
  msort Aa 0 N
  cnt

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve Xa |> stdout.WriteLine

solve 5 [|3;5;2;1;4|] |> should equal 6
solve 3 [|3;1;2|] |> should equal 2
