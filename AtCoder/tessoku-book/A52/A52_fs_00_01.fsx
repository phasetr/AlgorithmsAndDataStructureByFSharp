#r "nuget: FsUnit"
open FsUnit

(*
let Q,Qa = 5,[|[|"1";"taro"|];[|"1";"hanako"|];[|"2"|];[|"3"|];[|"2"|]|]
*)
let solve Q (Qa:string[][]) =
  let que = System.Collections.Generic.Queue<string>()
  for qa in Qa do
    if qa.[0]="1" then que.Enqueue(qa.[1])
    elif qa.[0]="2" then stdout.WriteLine (que.Peek())
    else que.Dequeue() |> ignore

let Q = stdin.ReadLine() |> int
let Qa = Array.init Q (fun _ -> stdin.ReadLine().Split())
solve Q Qa

(*
taro
hanako
*)
