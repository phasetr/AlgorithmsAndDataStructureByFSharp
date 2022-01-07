#r "nuget: FsUnit"
open FsUnit

let solve n (x: int64) (xs: int64 array) =
    if x = Array.sum xs then
        n
    else
        let ys = Array.sort xs

        Array.map (fun i -> ys.[..i]) [| 0 .. (n - 1) |]
        |> Array.map Array.sum
        |> Array.filter (fun s -> s <= x)
        |> Array.length
        |> fun len -> if len = n then n - 1 else len

let N, x =
    stdin.ReadLine().Split()
    |> fun y -> (int y.[0], int64 y.[1])

let xs =
    stdin.ReadLine().Split() |> Array.map int64

solve N x (Array.sort xs) |> printfn "%A"

solve 3 70L [| 20L; 30L; 10L |] |> should equal 2

solve 3 10L [| 20L; 30L; 10L |] |> should equal 1

solve 4 1111L [| 1L; 10L; 100L; 1000L |]
|> should equal 4

solve 2 10L [| 20L; 20L |] |> should equal 0
