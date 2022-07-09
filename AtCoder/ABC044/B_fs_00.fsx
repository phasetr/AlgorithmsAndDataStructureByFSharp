#r "nuget: FsUnit"
open FsUnit

let solve w =
    w |> Array.ofSeq
    |> Array.groupBy id
    |> Array.forall (fun x -> (snd x).Length%2 = 0)
    |> fun x -> if x then "Yes" else "No"

let w = stdin.ReadLine()
solve w |> printfn "%s"

solve "abaccaba" |> should equal "Yes"
solve "hthth" |> should equal "No"
