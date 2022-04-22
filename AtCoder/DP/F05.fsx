#r "nuget: FsUnit"
open FsUnit
let s,t = "axyb","abyxb"
let solve (s:string) (t:string) =
    let rec substr (dp:_[,]) i j =
        if dp.[i,j] = 0 then []
        elif dp.[i,j] = dp.[i-1,j] then substr dp (i-1) j
        elif dp.[i,j] = dp.[i,j-1] then substr dp i (j-1)
        else t.[i-1] :: substr dp (i-1) (j-1)

    ([Array.zeroCreate (s.Length+1)], [|0..t.Length-1|])
    ||> Array.fold (fun dp j ->
        ([],[|0..s.Length|])
        ||> Array.fold (fun acc i ->
            let dp0 = List.head dp
            match i with
            | 0 -> 0 :: acc
            | i when s.[i-1] = t.[j] -> (dp0.[i-1]+1) :: acc
            | i -> (max dp0.[i] (List.head acc)) :: acc)
        |> (List.rev >> List.toArray >> (fun e -> e::dp)))
    |> (List.rev >> List.toArray >> array2D)
    |> (fun (dp:int[,]) ->
        let i = Array2D.length1 dp - 1
        let j = Array2D.length2 dp - 1
        substr dp i j |> (List.rev >> List.toArray >> System.String))
let s = stdin.ReadLine()
let t = stdin.ReadLine()
solve s t |> stdout.WriteLine

solve "axyb" "abyxb" |> should equal "ayb"
solve "aa" "xayaz" |> should equal "aa"
solve "a" "z" |> should equal ""
solve "abracadabra" "avadakedavra" |> should equal "aaadara"
