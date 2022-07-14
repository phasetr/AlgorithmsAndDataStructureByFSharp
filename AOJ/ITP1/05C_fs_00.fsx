#r "nuget: FsUnit"
open FsUnit

let solve H W = [|1..H|] |> Array.map (fun i -> [|1..W|] |> Array.map (fun j -> if (i+j)%2=0 then "#" else ".") |> String.concat "")

let rec main() =
  match stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1]) with
    | 0,0 -> ()
    | H,W -> solve H W;;printfn "";; main()

solve 3 4 |> should equal [|"#.#.";".#.#";"#.#."|]
solve 5 6 |> should equal [|"#.#.#.";".#.#.#";"#.#.#.";".#.#.#";"#.#.#."|]
solve 3 3 |> should equal [|"#.#";".#.";"#.#"|]
solve 2 2 |> should equal [|"#.";".#"|]
solve 1 1 |> should equal [|"#"|]
