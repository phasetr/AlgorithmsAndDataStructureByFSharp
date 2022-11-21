#r "nuget: FsUnit"
open FsUnit

let H,N,Xa = 9,3,[|(8,3);(4,2);(2,1)|]
let H,N,Xa = 100,6,[|(1,1);(2,3);(3,9);(4,27);(5,81);(6,243)|]
let solve H N (Xa:((int*int)[])) =
  let dp = Array.create 10001 System.Int32.MaxValue |> fun a -> Array.set a 0 0; a
  for i in 1..H do
    for j in 0..N-1 do
      let (a,b) = Xa.[j]
      dp.[i] <- min dp.[i] (b + if i>a then dp.[i-a] else 0)
  dp.[H]

let H,N = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Xa = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve H N Xa |> stdout.WriteLine

solve 9 3 [|(8,3);(4,2);(2,1)|] |> should equal 4
solve 100 6 [|(1,1);(2,3);(3,9);(4,27);(5,81);(6,243)|] |> should equal 100
solve 9999 10 [|(540,7550);(691,9680);(700,9790);(510,7150);(415,5818);(551,7712);(587,8227);(619,8671);(588,8228);(176,2461)|] |> should equal 139815
