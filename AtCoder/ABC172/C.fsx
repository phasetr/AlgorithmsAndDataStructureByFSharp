// https://atcoder.jp/contests/abc172/tasks/abc172_c
// TLE になる
let rec books: int64 [] -> int64 [] -> int64 [] -> int64 [] =
    fun a b acc ->
        if a.Length = 0 then
            Array.append acc b
        else if b.Length = 0 then
            Array.append acc a
        else if a.[0] < b.[0] then
            if a.Length = 1
            then books [||] b (Array.append acc [| a.[0] |])
            else books (a |> Array.tail) b (Array.append acc [| a.[0] |])
        else if b.Length = 1 then
            books a [||] (Array.append acc [| a.[0] |])
        else
            books a (b |> Array.tail) (Array.append acc [| b.[0] |])

let rec judge: int64 -> int64 -> int -> int64 [] -> int =
    fun k acc n books ->
        if books.Length = 0 then n
        elif acc + books.[0] <= k then judge k (acc + books.[0]) (n + 1) (books |> Array.tail)
        else n

//let input = [| [| 3L;4L;240L|], [|60L;90L;120L|], [|80L; 150L; 80L; 150L|];
//               [| 3L;4L;730L|], [|60L;90L;120L|], [|80L; 150L; 80L; 150L|];
//               [| 5L;4L;1L|], [|1000000000L;1000000000L;1000000000L;1000000000L;1000000000L|], [|1000000000L; 1000000000L; 1000000000L; 1000000000L|]
//               |];
//for [| _; _; k |], a, b in input do (books a b [||] |> judge k 0L 0 |> printfn "%d")
// expected: 3; 7; 0

[<EntryPoint>]
let main argv =
    let _, _, k =
        stdin.ReadLine().Split()
        |> fun x -> x.[0], x.[1], x.[2] |> int64

    let a =
        stdin.ReadLine().Split() |> Array.map int64

    let b =
        stdin.ReadLine().Split() |> Array.map int64

    books a b [||] |> judge k 0L 0 |> printfn "%d"
    0
