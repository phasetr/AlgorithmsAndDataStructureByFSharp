#r "nuget: FsUnit"
open FsUnit

// let N,Aa = 5,[|2L;2L;3L;5L;5L|]
// let N,Aa = 7,[|1L;1L;1L;1L;2L;3L;4L|]
// let N,Aa = 6,[|6L;5L;4L;3L;2L;1L|]
let solve N Aa =
  let Ba = Aa |> Array.mapi (fun i a -> a - (int64 (i+1)))
  let Ma = Ba |> Array.sort |> fun Ba -> if N%2=1 then [|Ba.[N/2]|] else [|Ba.[N/2-1];Ba.[N/2]|]
  Ma |> Array.map (fun b -> Ba |> Array.sumBy (fun x -> abs(x-b))) |> Array.min

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N Aa |> stdout.WriteLine

solve 5 [|2L;2L;3L;5L;5L|] |> should equal 2L
solve 9 [|1L..9L|] |> should equal 0
solve 6 [|6L;5L;4L;3L;2L;1L|] |> should equal 18L
solve 7 [|1L;1L;1L;1L;2L;3L;4L|] |> should equal 6L
