#r "nuget: FsUnit"
open FsUnit

(*
let A,B = 2L,4L
let A,B = 123L,456L
let A,B = 123456789012L,123456789012L
let A,B = 0L,0L
let solve (A:int64) B = [|A..B|] |> Array.reduce (fun a b -> a^^^b)
*)

let solve A B =
  let g x = Array.get [|x;1L;x+1L;0L|] ((x+4L)%4L |> int)
  g (A-1L) ^^^ g B

let A,B = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0],x.[1])
solve A B |> stdout.WriteLine

solve 2L 4L |> should equal 5L
solve 123L 456L |> should equal 435L
solve 123456789012L 123456789012L |> should equal 123456789012L
solve 0L 0L |> should equal 0L
solve 0L 1L |> should equal 1L
solve 0L 1000000000000L |> should equal 1000000000000L

let benchmark i =
  let N = pown 10L i
  let sw = System.Diagnostics.Stopwatch()
  sw.Start()
  let mutable x = 0L
  for i in 0L..N do x <- x^^^i
  sw.Stop()
  printfn "FOR 10^%2d: %A" i (sw.Elapsed)
for i in 0..11 do benchmark i

[|0..16|]
|> Array.map (fun i -> sprintf "i = %2d, i%%4 = %d, sum = %2d" i (i%4) ([|0..i|] |> Array.reduce (fun a b -> a^^^b)))
|> Array.iter (printfn "%A")

(0)                                                                |> should equal 0
(0^^^1)                                                            |> should equal 1
(0^^^1)^^^(2)                                                      |> should equal 3
(0^^^1)^^^(2^^^3)                                                  |> should equal 0
(0^^^1)^^^(2^^^3)^^^(4)                                            |> should equal 4
(0^^^1)^^^(2^^^3)^^^(4^^^5)                                        |> should equal 1
(0^^^1)^^^(2^^^3)^^^(4^^^5)^^^(6)                                  |> should equal 7
(0^^^1)^^^(2^^^3)^^^(4^^^5)^^^(6^^^7)                              |> should equal 0
(0^^^1)^^^(2^^^3)^^^(4^^^5)^^^(6^^^7)^^^(8)                        |> should equal 8
(0^^^1)^^^(2^^^3)^^^(4^^^5)^^^(6^^^7)^^^(8^^^9)                    |> should equal 1
(0^^^1)^^^(2^^^3)^^^(4^^^5)^^^(6^^^7)^^^(8^^^9)^^^(10)             |> should equal 11
(0^^^1)^^^(2^^^3)^^^(4^^^5)^^^(6^^^7)^^^(8^^^9)^^^(10^^^11)        |> should equal 0
(0^^^1)^^^(2^^^3)^^^(4^^^5)^^^(6^^^7)^^^(8^^^9)^^^(10^^^11)^^^(12) |> should equal 12
