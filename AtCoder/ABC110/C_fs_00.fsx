#r "nuget: FsUnit"
open FsUnit

let S,T = "abcdefghijklmnopqrstuvwxyz","ibyhqfrekavclxjstdwgpzmonu"
let solve S T =
  let rec group = function | [] -> [] | x::xs -> (x::(List.takeWhile ((=) x) xs))::group (List.skipWhile ((=) x) xs)
  let freq = Seq.toList >> List.sort >> group >> List.map (List.length) >> List.sort
  if freq S = freq T then "Yes" else "No"

let S = stdin.ReadLine()
let T = stdin.ReadLine()
solve S T |> stdout.WriteLine

solve "azzel" "apple" |> should equal "Yes"
solve "chokudai" "redcoder" |> should equal "No"
solve "abcdefghijklmnopqrstuvwxyz" "ibyhqfrekavclxjstdwgpzmonu" |> should equal "Yes"
