#r "nuget: FsUnit"
open FsUnit

let N,H,Aa = 1,10,[|(3,5)|]
let N,H,Aa = 5,500,[|(35,44);(28,83);(46,62);(31,79);(40,43)|]
let solve N H Aa =
  let cmax = Aa |> Array.map fst |> Array.max
  let Ta = Aa |> Array.choose (fun x -> if snd x <= cmax then None else Some (snd x))
  let dts =
    ((0,0),Ta |> Array.sortDescending) ||> Array.fold (fun (n,d) t -> ((if H<=d then n else n+1), d+t))
  if H<=snd dts then fst dts
  else
    let (n,dt) = dts
    if (H-dt)%cmax=0 then n+(H-dt)/cmax else n+1+(H-dt)/cmax

let N,H = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Aa = [| for i in 1..N do (stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1]) |]
solve N H Aa |> stdout.WriteLine

solve 1 10 [|(3,5)|] |> should equal 3
solve 2 10 [|(3,5);(2,6)|] |> should equal 2
solve 4 1000000000 [|(1,1);(1,10000000);(1,30000000);(1,99999999)|] |> should equal 860000004
solve 5 500 [|(35,44);(28,83);(46,62);(31,79);(40,43)|] |> should equal 9
