// https://atcoder.jp/contests/abc085/tasks/abc085_c
// コンテストで通らない
let fc n y =
    let pairs =
        [ for i in 0 .. n do
            for j in 0 .. (n - i) do
                let k = n - i - j
                let money = 10000 * i + 5000 * j + 1000 * k
                if money = y then [| i; j; k |] ]

    match pairs with
    | [] -> "-1 -1 -1"
    | p :: ps -> sprintf "%d %d %d" (Array.get p 0) (Array.get p 1) (Array.get p 2)

let test () =
    fc 9 45000 |> printfn "%s"
    fc 20 196000 |> printfn "%s"
    fc 1000 1234000 |> printfn "%s"
    fc 2000 20000000 |> printfn "%s"

test ()

let main () =
    let input =
        stdin.ReadLine().Split(' ') |> Array.map int

    let n = input.[0]
    let y = input.[1]
    fc n y |> printfn "%s"

//main ()
