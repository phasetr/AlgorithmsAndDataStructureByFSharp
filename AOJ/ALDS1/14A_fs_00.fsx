#r "nuget: FsUnit"
open FsUnit

let solve T P =
  let l1 = String.length T
  let l2 = String.length P
  let rec loop (i: int) (r: int list) =
    if l1-l2<i then r
    else let s = T.Substring(i,l2) in loop (i+1) (if s = P then i::r else r)
  loop 0 [] |> List.rev

let T = stdin.ReadLine()
let P = stdin.ReadLine()
solve Xa |> Array.iter (stdout.WriteLine)

solve "aabaaa" "aa" |> should equal [0;3;4]
solve "xyzz" "yz" |> should equal [1]
solve "abc" "xyz" |> should equal ([]: int list)
