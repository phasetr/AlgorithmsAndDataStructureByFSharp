#r "nuget: FsUnit"
open FsUnit

// ['a'..'y'] |> List.map succ
// let N = 1
// let N = 2
let solve N =
  let succ (c:char) = int c |> (+) 1 |> char
  let f (s,c) = ['a'..c] |> List.map (fun d -> (d::s, if d=c then succ c else c))
  ([(['a'],'b')], [2..N])
  ||> List.fold (fun acc _ -> acc |> List.collect f)
  |> List.map (fst >> List.rev >> System.String.Concat)

let N = stdin.ReadLine() |> int
solve N |> List.iter stdout.WriteLine

solve 1 |> should equal ["a"]
solve 2 |> should equal ["aa";"ab"]
