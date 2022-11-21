#r "nuget: FsUnit"
open FsUnit

let H,N,Xa = 9,3,[|(8,3);(4,2);(2,1)|]
let H,N,Xa = 100,6,[|(1,1);(2,3);(3,9);(4,27);(5,81);(6,243)|]
let solve H N (Xa:((int*int)[])) =
  let inline memorec f size =
    let dp = Array.create size None
    let rec g x =
      match dp.[x] with
        | None -> let v = f g x in dp.[x] <- Some v; v
        | Some v -> v
    g
  let f cost h =
    (System.Int32.MaxValue, Xa)
    ||> Array.fold (fun prev (a,b) -> min prev (b + if h<=a then 0 else cost (h-a)))
  H |> memorec f 10001

let H,N = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Xa = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve H N Xa |> stdout.WriteLine

solve 9 3 [|(8,3);(4,2);(2,1)|] |> should equal 4
solve 100 6 [|(1,1);(2,3);(3,9);(4,27);(5,81);(6,243)|] |> should equal 100
solve 9999 10 [|(540,7550);(691,9680);(700,9790);(510,7150);(415,5818);(551,7712);(587,8227);(619,8671);(588,8228);(176,2461)|] |> should equal 139815
