#r "nuget: FsUnit"
open FsUnit

(*
let N,K,Aa = 6,30,[|5;1;18;7;2;9|]
let N,K,Aa = 1,648,[|648|]
*)
let solve N K Aa =
  let rec nonEmptySubsequences = function
    | [] -> []
    | x::xs -> let f ys r = ys :: (x :: ys) :: r in [x] :: List.foldBack f (nonEmptySubsequences xs) []
  let subsequences xs = [] :: nonEmptySubsequences xs
  let bs,cs = Aa |> Array.toList |> List.splitAt (N/2)
  let bss = bs |> subsequences |> List.map (List.sum) |> set
  subsequences cs
  |> List.exists (fun c -> bss |> Set.contains (K - List.sum c))
  |> fun b -> if b then "Yes" else "No"
let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N K Aa |> stdout.WriteLine

solve 6 30 [|5;1;18;7;2;9|] |> should equal "Yes"
// 10_random_small_02.txt
solve 1 648 [|648|] |> should equal "Yes"
// 10_random_small_08.txt
solve 7 98 [|5518;5834;8711;1325;98;1783;7652|] |> should equal "Yes"
// 10_random_small_10.txt
solve 5 45230042 [|1252;9096;45230042;8440;8355|] |> should equal "Yes"
