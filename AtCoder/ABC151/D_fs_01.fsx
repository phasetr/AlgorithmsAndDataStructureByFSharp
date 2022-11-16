// https://atcoder.jp/contests/abc151/submissions/9489743
open System
open System.Collections.Generic

[<AutoOpen>]
module Cin =
    let read f = stdin.ReadLine() |> f
    let reada f = stdin.ReadLine().Split() |> Array.map f
    let readChars() = read string |> Seq.toArray
    let readInts() = readChars() |> Array.map (fun x -> Convert.ToInt32(x.ToString()))

[<AutoOpen>]
module Cout =
    let writer = new IO.StreamWriter(new IO.BufferedStream(Console.OpenStandardOutput()))
    let print (s: string) = writer.Write s
    let println (s: string) = writer.WriteLine s
    let inline puts (s: ^a) = string s |> println

let mutable H = 0
let mutable W = 0

let d4 =
    [ (-1, 0)
      (0, -1)
      (0, 1)
      (1, 0) ]

let main() =
    let [| h; w |] = reada int
    H <- h
    W <- w
    let maze = Array2D.init H W (fun h w -> '#')
    for h in 0 .. H - 1 do
        let s = read string
        for w in 0 .. W - 1 do
            maze.[h, w] <- s.[w]
    let mutable ans = 0
    for sy in 0 .. H - 1 do
        for sx in 0 .. W - 1 do
            if maze.[sy, sx] = '#' then
                ()
            else
                let dist = Array2D.init H W (fun h w -> Int32.MaxValue)
                dist.[sy, sx] <- 0
                let mutable que = Queue<int * int>()
                que.Enqueue((sy, sx))
                while que.Count > 0 do
                    let y, x = que.Dequeue()
                    for (dy, dx) in d4 do
                        let ny, nx = y + dy, x + dx
                        if ny < 0 || H <= ny || nx < 0 || W <= nx then
                            ()
                        else if maze.[ny, nx] = '#' then
                            ()
                        else
                            let cost = dist.[y, x] + 1
                            if cost < dist.[ny, nx] then
                                dist.[ny, nx] <- cost
                                que.Enqueue((ny, nx))

                let mutable tmp = 0
                for y in 0 .. H - 1 do
                    for x in 0 .. W - 1 do
                        if maze.[y, x] = '.' then tmp <- max tmp dist.[y, x]
                // sprintf "sy: %d. sx: %d, tmp: %d" sy sx tmp |> puts
                ans <- max ans tmp

    puts ans
    ()

main()
writer.Close()
