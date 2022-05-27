#r "nuget: FsUnit"
open FsUnit
let H,W,Aa = 3,4,[|[|'.';'.';'.';'#'|];[|'.';'#';'.';'.'|];[|'.';'.';'.';'.'|]|]
let solve H W (Aa:char[][]) =
    let (+%) n m = (n+m) % ((pown 10 9) + 7)
    (Array2D.zeroCreate H W, [|0..H-1|])
    ||> Array.fold (fun (dp:int[,]) i ->
        (dp,[|0..W-1|]) ||> Array.fold (fun dp j ->
            if (i,j)=(0,0) then Array2D.set dp i j 1; dp
            elif Aa.[i].[j]='#' then dp
            elif i=0 then Array2D.set dp i j dp.[i,j-1]; dp
            elif j=0 then Array2D.set dp i j dp.[i-1,j]; dp
            else Array2D.set dp i j (dp.[i-1,j] +% dp.[i,j-1]); dp))
    |> fun dp -> dp.[H-1,W-1]
let H,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Aa = [| for i in 1..H do (stdin.ReadLine() |> Seq.toArray) |]
solve H W Aa |> stdout.WriteLine

solve 3 4 [|[|'.';'.';'.';'#'|];[|'.';'#';'.';'.'|];[|'.';'.';'.';'.'|]|] |> should equal 3
solve 5 2 [|[|'.'; '.'|]; [|'#'; '.'|]; [|'.'; '.'|]; [|'.'; '#'|]; [|'.'; '.'|]|] |> should equal 0
solve 5 5 [|[|'.'; '.'; '#'; '.'; '.'|]; [|'.'; '.'; '.'; '.'; '.'|];[|'#'; '.'; '.'; '.'; '#'|]; [|'.'; '.'; '.'; '.'; '.'|];[|'.'; '.'; '#'; '.'; '.'|]|] |> should equal 24
solve 20 20 [|[|'.'; '.'; '.'; '.'; '.'; '.'; '.'; '.'; '.'; '.'; '.'; '.'; '.'; '.';'.'; '.'; '.'; '.'; '.'; '.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|];[|'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.';'.'|]|] |> should equal 345263555