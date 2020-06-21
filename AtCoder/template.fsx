//////////////////////////// Utils start
let fext =
    System.IO.Path.GetExtension __SOURCE_FILE__

let isDev = fext = ".fsx"

let initInfinite64 f =
    seq {
        let mutable i = 0L
        while true do
            yield f i
            i <- i + 1L
    }

let (|SeqEmpty|SeqCons|) (xs: 'a seq) =
    if Seq.isEmpty xs then SeqEmpty else SeqCons(Seq.head xs, Seq.skip 1 xs)

let rec group xs: seq<seq<'a>> =
    match xs with
    | SeqEmpty -> Seq.empty
    | SeqCons (x, xs) ->
        let ys: 'a seq = Seq.takeWhile ((=) x) xs
        let zs: 'a seq = Seq.skipWhile ((=) x) xs
        Seq.append (seq { Seq.append (seq { x }) ys }) (group zs)

let testInput (filePath: string) =
    seq {
        use sr = new System.IO.StreamReader(filePath)
        while not sr.EndOfStream do
            yield sr.ReadLine()
    }
    |> Array.ofSeq
//////////////////////////// Utils end
let main a = a // 主結果

let trial =
    if isDev then
        // テスト
        let a1 = testInput "A1.txt"
        main a1 |> printfn "%A"
        let a2 = testInput "A2.txt"
        main a2 |> printfn "%A"
    else
        stdin.ReadLine() |> ignore

        let a =
            stdin.ReadLine().Split(' ') |> Array.map int

        main a |> printfn "%A"
