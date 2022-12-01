#r "nuget: FsUnit"
open FsUnit

// let N = 2
// let N = 3
let solve N =
  let succ (c:char) = int c |> (+) 1 |> char
  let m xs = List.max xs |> succ
  let rec frec n acc =
    if n=1 then acc
    else acc |> List.collect (fun xs -> ['a'..(m xs)] |> List.map (fun c -> c::xs)) |> frec (n-1)
  frec N [['a']] |> List.map (List.rev >> System.String.Concat)

let N = stdin.ReadLine() |> int
solve N |> List.iter stdout.WriteLine

solve 1 |> should equal ["a"]
solve 2 |> should equal ["aa";"ab"]
solve 3 |> should equal ["aaa";"aab";"aba";"abb";"abc"]
