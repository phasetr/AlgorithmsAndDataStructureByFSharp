#r "nuget: FsUnit"
open FsUnit

let solve N K (Ha:int[]) =
    let f l h =
        let f (ci,hi) = ci + abs (hi-h)
        let c = Seq.truncate K l |> Seq.map f |> Seq.min
        (c,h) :: l
    Seq.fold f [(0,Ha.[0])] (Array.toSeq Ha) |> Seq.head |> fst
let N, K = stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0], x.[1]
let Ha = stdin.ReadLine().Split() |> Array.map int
solve N K Ha |> stdout.WriteLine

solve 5 3 [|10;30;40;50;20|] |> should equal 30
solve 3 1 [|10;20;10|] |> should equal 20
solve 2 100 [|10;10|] |> should equal 0
solve 10 4 [|40;10;20;70;80;10;20;70;80;60|] |> should equal 40

let test N K (Ha:int[]) =
    let f l h =
        let f (ci,hi) = ci + abs (hi-h)
        let c = Seq.truncate K l |> Seq.map f |> Seq.min
        (c,h) :: l
    Seq.scan f [(0,Ha.[0])] (Array.toSeq Ha.[1..])
test 5 3 [|10;30;40;50;20|] |> Seq.iter (printfn "%A")
test 3 1 [|10;20;10|] |> Seq.iter (printfn "%A")
test 2 100 [|10;10|] |> Seq.iter (printfn "%A")
test 10 4 [|40;10;20;70;80;10;20;70;80;60|] |> Seq.iter (printfn "%A")
