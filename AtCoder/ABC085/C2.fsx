(*
https://atcoder.jp/contests/abc085/tasks/abc085_c
これもコンテストで通らない。
コンテスト時のコンパイラに Option.defaultValue がない？
*)

let fc n y =
    seq {
        for i in 0 .. n do
            for j in 0 .. (n - i) do
                (i, j, n - i - j)
    }
    |> Seq.tryFind (fun (i, j, k) -> 10000 * i + 5000 * j + 1000 * k = y)
    |> Option.defaultValue ((-1, -1, -1))
    |> fun (i, j, k) -> printfn "%d %d %d" i j k

let test () =
    let n = 9
    let y = 45000
    fc n y

test ()

let main () =
    let a =
        stdin.ReadLine().Split(' ') |> Array.map int

    let n = a.[0]
    let y = a.[1]
    fc n y

main ()
main ()
