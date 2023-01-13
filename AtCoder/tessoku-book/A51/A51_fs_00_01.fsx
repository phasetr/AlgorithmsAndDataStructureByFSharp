#r "nuget: FsUnit"
open FsUnit

(*
let Q,Qa = 5,[|[|"1";"futuremap"|];[|"1";"howtospeak"|];[|"2"|];[|"3"|];[|"2"|]|]
*)
let solve Q (Qa:string[][]) =
  ([],Qa)
  ||> Array.fold (fun acc q ->
    if q.[0]="1" then q.[1]::acc
    elif q.[0]="2" then stdout.WriteLine (List.head acc); acc
    else List.tail acc)

let Q = stdin.ReadLine() |> int
let Qa = Array.init Q (fun _ -> stdin.ReadLine().Split())
solve Q Qa
