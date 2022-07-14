#r "nuget: FsUnit"
open FsUnit

let solve H W = [|1..H|] |> Array.map (fun i -> if i=1 || i=H then String.replicate W "#" else String.concat "" [|"#"; String.replicate (W-2) "."; "#"|])
let rec main() =
  match stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1]) with
    | 0,0 -> ()
    | H,W -> solve H W;;printfn "";; main // TODO これ動く? きちんと改行した方がいい?

solve 3 4 |> should equal [|"####";"#..#";"####"|]
solve 5 6 |> should equal [|"######";"#....#";"#....#";"#....#";"######";|]
solve 3 3 |> should equal [|"###";"#.#";"###";|]
