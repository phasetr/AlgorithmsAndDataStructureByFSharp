#r "nuget: FsUnit"
open FsUnit

(*
let S,T = "tokyo","Kyoto"
let S,T = "competitive","programming"
let S,T = "abcdef","bdf"
*)
let solve S T =
  let sLen = S |> String.length
  let tLen = T |> String.length
  Array2D.create (sLen+1) (tLen+1) 0
  |> fun dp ->
    for i in 0..sLen do
      for j in 0..tLen do
        dp.[i,j] <-
          if i=0 then j
          elif j=0 then i
          else
            let c = if S.[i-1]=T.[j-1] then 0 else 1
            [dp.[i-1,j]+1;dp.[i,j-1]+1;dp.[i-1,j-1]+c] |> List.min
    dp.[sLen,tLen]
let S = stdin.ReadLine()
let T = stdin.ReadLine()
solve S T |> stdout.WriteLine

solve "tokyo" "Kyoto" |> should equal 4
solve "competitive" "programming" |> should equal 10
solve "abcdef" "bdf" |> should equal 3
