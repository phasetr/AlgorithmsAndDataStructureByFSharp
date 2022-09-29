#r "nuget: FsUnit"
open FsUnit

let solve T P =
  let n = String.length T
  let m = String.length P
  [|0..n-m|] |> Array.choose (fun l -> if T.Substring(l,m)=P then Some(l) else None)

solve "aabaaa" "aa" |> should equal [|0;3;4|]
solve "xyzz" "yz" |> should equal [|1|]
solve "abc" "xyz" |> should equal ([||]: int[])
