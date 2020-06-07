(*
https://atcoder.jp/contests/abc086/tasks/arc089_a
https://qiita.com/kuuso1/items/606b75c172cafa1d07f6#%E7%AC%AC-10-%E5%95%8F-abc-086-c---traveling
*)
#nowarn "25"

let checkCoords (((t1, x1, y1), (t2, x2, y2)): (int * int * int) * (int * int * int)) =
    let dt: int = t2 - t1
    let d: int = ((x2 - x1) |> abs) + ((y2 - y1) |> abs)
    d <= dt && (d % 2 = dt % 2)

let test () =
    [| (0, 0, 0); (3, 1, 2); (6, 1, 1) |]
    |> Array.pairwise
    |> Array.map checkCoords
    |> Array.fold (&&) true
    |> fun x -> if x then printfn "Yes" else printfn "No"

test ()

let main () =
    let n = stdin.ReadLine() |> int
    let targetCoords: (int * int * int) [] = Array.zeroCreate (n + 1)
    targetCoords.[0] <- (0, 0, 0)
    for i in [ 1 .. n ] do
        let [| x; y; z |] =
            stdin.ReadLine().Split(' ') |> Array.map int

        targetCoords.[i] <- (x, y, z)
    targetCoords
    |> Array.pairwise
    |> Array.map checkCoords
    |> Array.fold (&&) true
    |> fun x -> if x then printfn "Yes" else printfn "No"

main ()
