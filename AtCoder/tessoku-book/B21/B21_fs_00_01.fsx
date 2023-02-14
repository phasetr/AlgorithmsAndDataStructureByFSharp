#r "nuget: FsUnit"
open FsUnit

(*
let N,S = 11,"programming"
let N,S = 7,"abcdcba"
*)
let solve N (S:string) =
  Array2D.create N N 0
  |> fun dp ->
    for i in N-1..(-1)..0 do
      dp.[i,i] <- 1
      for j in i+1..N-1 do
        dp.[i,j] <- max dp.[i,j-1] dp.[i+1,j]
        if S.[i]=S.[j] then dp.[i,j] <- max (dp.[i+1,j-1]+2) dp.[i,j]
    dp.[0,N-1]

let N = stdin.ReadLine() |> int
let S = stdin.ReadLine()
solve N S |> stdout.WriteLine

solve 11 "programming" |> should equal 4
solve 7 "abcdcba" |> should equal 7
