#r "nuget: FsUnit"
open FsUnit

// let N,Aa = 5,[|6L;8L;1L;2L;3L|]
let solve N (Aa:int64[]) =
  let rec frec acc low high = function
    | (l::ls),(h::hs) -> frec (acc + h-low + high-l) l h (ls,hs)
    | [],[h] -> acc + (max (h-low) (high - h))
    | _,_ -> acc
  let (xs,ys) = Aa |> Array.sort |> Array.toList |> List.splitAt (N/2)
  let (l,ls) = (List.head xs, List.tail xs)
  let (h,hs) = ys |> List.rev |> fun zs -> (List.head zs, List.tail zs)
  frec (h-l) l h (ls,hs)

let N = stdin.ReadLine() |> int
let Aa = Array.init N (fun _ -> stdin.ReadLine() |> int64)
solve N Aa |> stdout.WriteLine

solve 5 [|6L;8L;1L;2L;3L|] |> should equal 21L
solve 6 [|3L;1L;4L;1L;5L;9L|] |> should equal 25L
solve 3 [|5L;5L;1L|] |> should equal 8L
