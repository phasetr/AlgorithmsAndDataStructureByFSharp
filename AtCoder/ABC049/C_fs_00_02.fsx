#r "nuget: FsUnit"
open FsUnit

let S = "erasedream"
nnlet solve S =
  let Ta = [|"dream";"dreamer";"erase";"eraser"|]
  let rec check acc (s:string) i =
    if s="" || i<0 then acc
    else
      if Array.contains s.[i..] Ta then check true s.[0..i-1] i
      else check false s (i-1)
  if check false S (String.length S) then "YES" else "NO"

let S = stdin.ReadLine()
solve S |> stdout.WriteLine

solve "erasedream" |> should equal "YES"
solve "dreameraser" |> should equal "YES"
solve "dreamerer" |> should equal "NO"
