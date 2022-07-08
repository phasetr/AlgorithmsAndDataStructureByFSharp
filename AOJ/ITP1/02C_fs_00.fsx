#r "nuget: FsUnit"
open FsUnit

let solve (Xa: int[]) = Xa |> Array.sort |> Array.map string |> String.concat " "

let Xa = stdin.ReadLine().Split() |> Array.map int
solve Xa |> stdout.WriteLine

solve [|3;8;1|] |> should equal "1 3 8"
