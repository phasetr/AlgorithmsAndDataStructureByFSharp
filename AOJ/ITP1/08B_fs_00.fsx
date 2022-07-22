#r "nuget: FsUnit"
open FsUnit

let solve x = x |> Seq.map (string >> int) |> Seq.reduce (fun acc s -> acc+s)

let main() =
  match stdin.ReadLine() with
    | "0" -> ()
    | s -> solve x; main()

[|"123";"55";"1000"|] |> Array.map solve |> should equal [|6;10;1|]
