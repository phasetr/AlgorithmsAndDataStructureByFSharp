#r "nuget: FsUnit"
open FsUnit

let solve n =
  let contain3 = string >> Seq.contains '3'
  Array.filter (fun k -> k%3=0 || contain3 k) [|1..n|]

let n = stdin.ReadLine() |> int
solve n |> Array.map (fun i -> sprintf " %d" i) |> String.concat "" |> stdout.WriteLine

solve 30 |> should equal [|3;6;9;12;13;15;18;21;23;24;27;30|]
solve 60 |> should equal [|3;6;9;12;13;15;18;21;23;24;27;30;31;32;33;34;35;36;37;38;39;42;43;45;48;51;53;54;57;60|]
