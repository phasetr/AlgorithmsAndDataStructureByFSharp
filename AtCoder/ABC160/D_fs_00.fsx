#r "nuget: FsUnit"
open FsUnit

let N,X,Y = 5,2,4
let solve N X Y =
  let d i j = min (abs (i-j)) (abs (i-X) + abs (j-Y) + 1)
  let Da = [| for i in 1..N-1 do for j in (i+1)..N do d i j |] |> Array.countBy id |> dict
  [|1..N-1|] |> Array.map (fun k -> Da.TryGetValue(k) |> function | true,n -> n | false,_ -> 0)

let N,X,Y = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1],x.[2])
solve N X Y |> Array.map string |> String.concat "\n" |> stdout.WriteLine

solve 5 2 4 |> should equal [|5;4;1;0|]
solve 3 1 3 |> should equal [|3;0|]
solve 7 3 7 |> should equal [|7;8;4;2;0;0|]
solve 10 4 8 |> should equal [|10;12;10;8;4;1;0;0;0|]
