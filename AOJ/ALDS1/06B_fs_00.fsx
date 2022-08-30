#r "nuget: FsUnit"
open FsUnit

let solve N Aa =
  let partition (a:int[]) p r =
    let swap i j = let tmp = a.[i] in a.[i] <- a.[j]; a.[j] <- tmp
    let rec frec i j =
      if j = r then (swap i r; i)
      else if a.[j] <= a.[r] then (swap i j; frec (i+1) (j+1))
      else frec i (j+1) in
    frec p p

  let k = partition Aa 0 (N-1)
  Aa |> Array.mapi (fun i e -> sprintf (if i = 0 then "%d" else if i = k then "[%d]" else "%d") e)
  |> String.concat " "

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve Aa |> stdout.WriteLine

solve 12 [|13;19;9;5;12;8;7;4;21;2;6;11|] |> should equal "9 5 8 7 4 2 6 [11] 21 13 19 12"
