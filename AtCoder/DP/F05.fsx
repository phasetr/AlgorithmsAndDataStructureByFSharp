#r "nuget: FsUnit"
open FsUnit
@"TODO バグあり: dpがうまく作れていない.
Pythonと比べて実装を確認しよう."
let s,t = "axyb","abyxb"
let solve (s:string) (t:string) =
    let rec substr (dp:_[,]) i j =
        if dp.[i,j] = 0 then []
        elif dp.[i,j] = dp.[i-1,j] then substr dp (i-1) j
        elif dp.[i,j] = dp.[i,j-1] then substr dp i (j-1)
        else t.[i-1] :: substr dp (i-1) (j-1)
    (Array2D.zeroCreate (s.Length+1) (t.Length+1), [|1..s.Length|])
    ||> Array.fold (fun dp i ->
        (dp,[|1..t.Length|])
        ||> Array.fold (fun dp j ->
            match i with
            | i when s.[i-1] = t.[j-1] -> Array2D.set dp i j (dp.[j-1,i-1]+1); dp
            | i -> Array2D.set dp i j (max dp.[i-1,j] dp.[i,j-1]); dp))
    |> (fun (dp:int[,]) -> substr dp s.Length t.Length |> (List.rev >> List.toArray >> System.String))
let s = stdin.ReadLine()
let t = stdin.ReadLine()
solve s t |> stdout.WriteLine

solve "axyb" "abyxb" |> should equal "ayb"
solve "aa" "xayaz" |> should equal "aa"
solve "a" "z" |> should equal ""
solve "abracadabra" "avadakedavra" |> should equal "aaadara"
