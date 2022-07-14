#r "nuget: FsUnit"
open FsUnit

// 入力全体を処理する関数は省略: 適当に再帰で書こう. またはOCaml参照.
let solve H W = Array.init H (fun _ -> String.replicate W "#")
let rec main() =
  match stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1]) with
    | 0,0 -> ()
    | H,W -> solve H W;;printfn "";; main // TODO これ動く? きちんと改行した方がいい?

let H,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
solve Xa |> stdout.WriteLine

solve 3 4 |> should equal [|"####";"####";"####"|]
solve 5 6 |> should equal [|"######";"######";"######";"######";"######"|]
solve 2 2 |> should equal [|"##";"##"|]
