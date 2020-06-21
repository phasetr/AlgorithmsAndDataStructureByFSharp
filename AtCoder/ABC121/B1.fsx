// https://atcoder.jp/contests/abc121/tasks/abc121_b
// https://atcoder.jp/contests/abc121/submissions/12277754
#nowarn "25"

let [| N; M; C |] =
    stdin.ReadLine().Split() |> Array.map int

let b =
    stdin.ReadLine().Split() |> Array.map int

let rec solver r i =
    if i = N then
        r
    else
        let a =
            stdin.ReadLine().Split() |> Array.map int

        let s =
            Array.zip a b
            |> Array.sumBy (fun x -> (fst x) * (snd x))

        if s + C > 0 then solver (r + 1) (i + 1) else solver r (i + 1)

solver 0 0 |> stdout.WriteLine
