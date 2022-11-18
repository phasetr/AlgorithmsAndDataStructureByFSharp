#r "nuget: FsUnit"
open FsUnit

let S = "xabxa"
let solveTLE S =
  let rec frec acc (S:string) =
    if S="" then acc
    else if S.[0]=S.[S.Length-1] then frec acc S.[1..S.Length-2]
    else
      if S.[0]='x' then frec (acc+1) (S+"x")
      else if S.[S.Length-1]='x' then frec (acc+1) ("x"+S)
      else -1
  frec 0 S

let solve S =
  let Sa = S |> Seq.toArray
  let rec frec acc l r =
    if r<=l then acc
    else if Sa.[l]=Sa.[r] then frec acc (l+1) (r-1)
    else
      if Sa.[l]='x' then frec (acc+1) (l+1) r
      else if Sa.[r]='x' then frec (acc+1) l (r-1)
      else -1
  frec 0 0 (Sa.Length-1)

let S = stdin.ReadLine()
solve S |> stdout.WriteLine

solve "xabxa" |> should equal 2
solve "ab" |> should equal -1
solve "a" |> should equal 0
solve "oxxx" |> should equal 3
