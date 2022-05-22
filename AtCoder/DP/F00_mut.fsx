#r "nuget: FsUnit"
open FsUnit
let s,t = "axyb","abyxb"
let solve (s:string) (t:string) =
    let rec substr (dp:_[,]) i j =
        if dp.[i,j] = 0 then []
        elif dp.[i,j] = dp.[i-1,j] then substr dp (i-1) j
        elif dp.[i,j] = dp.[i,j-1] then substr dp i (j-1)
        else s.[i-1] :: substr dp (i-1) (j-1)
    let mutable dp = Array2D.zeroCreate (s.Length+1) (t.Length+1)
    for i in 1..(s.Length) do
        for j in 1..(t.Length) do
            if s.[i-1]=t.[j-1] then dp.[i,j] <- dp.[i-1,j-1] + 1
            else dp.[i,j] <- max dp.[i,j-1] dp.[i-1,j]
    substr dp s.Length t.Length |> (List.rev >> List.toArray >> System.String)
let s = stdin.ReadLine()
let t = stdin.ReadLine()
solve s t |> stdout.WriteLine

solve "axyb" "abyxb" |> should equal "axb"
solve "aa" "xayaz" |> should equal "aa"
solve "a" "z" |> should equal ""
solve "abracadabra" "avadakedavra" |> should equal "aaadara"
