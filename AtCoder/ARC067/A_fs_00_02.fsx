#r "nuget: FsUnit"
open FsUnit

let N = 3
let solve N =
  let MOD = 1_000_000_007L
  let rec factorize n =
    if n=1 then []
    else
      let m = Seq.initInfinite ((+) 2) |> Seq.filter (fun i -> n%i=0) |> Seq.head
      m :: factorize (n/m)
  if N=1 then 1L
  else
    [1..N] |> List.collect factorize |> List.groupBy id
    |> List.map (snd >> List.length >> (+) 1 >> int64)
    |> List.reduce (fun x y -> (x*y)%MOD)

let N = stdin.ReadLine() |> int
solve N |> stdout.WriteLine

solve 3 |> should equal 4
solve 6 |> should equal 30
solve 1000 |> should equal 972926972
