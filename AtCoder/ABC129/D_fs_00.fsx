#r "nuget: FsUnit"
open FsUnit

// let H,W,Sa = 4,6,[|[|'#'; '.'; '.'; '#'; '.'; '.'|]; [|'.'; '.'; '.'; '.'; '.'; '#'|]; [|'.'; '.'; '.'; '.'; '#'; '.'|]; [|'#'; '.'; '#'; '.'; '.'; '.'|]|]
// let H,W,Sa = 8,8,[|[|'.'; '.'; '#'; '.'; '.'; '.'; '#'; '.'|];[|'.'; '.'; '.'; '.'; '#'; '.'; '.'; '.'|];[|'#'; '#'; '.'; '.'; '.'; '.'; '.'; '.'|];[|'.'; '.'; '#'; '#'; '#'; '.'; '.'; '#'|];[|'.'; '.'; '.'; '#'; '.'; '.'; '#'; '.'|];[|'#'; '#'; '.'; '.'; '.'; '.'; '#'; '.'|];[|'#'; '.'; '.'; '.'; '#'; '.'; '.'; '.'|];[|'#'; '#'; '#'; '.'; '#'; '.'; '.'; '#'|]|]
let solve H W (Sa:char[][]) =
  let mutable La = Array2D.create H W 0
  let mutable Ra = Array2D.create H W 0
  let mutable Ua = Array2D.create H W 0
  let mutable Da = Array2D.create H W 0
  for i0 in 0..H-1 do
    let i1 = H-1-i0
    for j0 in 0..W-1 do
      let j1 = W-1-j0
      if Sa.[i0].[j0]='#' then La.[i0,j0]<-0; Ua.[i0,j0]<-0
      else
        if i0=0 then Ua.[i0,j0]<-1 else Ua.[i0,j0]<-Ua.[i0-1,j0]+1
        if j0=0 then La.[i0,j0]<-1 else La.[i0,j0]<-La.[i0,j0-1]+1
      if Sa.[i1].[j1]='#' then Ra.[i1,j1]<-0; Da.[i1,j1]<-0
      else
        if i1=H-1 then Da.[i1,j1]<-1 else Da.[i1,j1]<-Da.[i1+1,j1]+1
        if j1=W-1 then Ra.[i1,j1]<-1 else Ra.[i1,j1]<-Ra.[i1,j1+1]+1
  (0,[| for i in 0..H-1 do for j in 0..W-1 do (i,j) |])
  ||> Array.fold (fun acc (i,j) -> max acc (La.[i,j]+Ra.[i,j]+Ua.[i,j]+Da.[i,j]-3))

let H,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Sa = Array.init H (fun _ -> stdin.ReadLine().ToCharArray())
solve H W Sa |> stdout.WriteLine

solve 4 6 [|[|'#'; '.'; '.'; '#'; '.'; '.'|]; [|'.'; '.'; '.'; '.'; '.'; '#'|]; [|'.'; '.'; '.'; '.'; '#'; '.'|]; [|'#'; '.'; '#'; '.'; '.'; '.'|]|] |> should equal 8
solve 8 8 [|[|'.'; '.'; '#'; '.'; '.'; '.'; '#'; '.'|];[|'.'; '.'; '.'; '.'; '#'; '.'; '.'; '.'|];[|'#'; '#'; '.'; '.'; '.'; '.'; '.'; '.'|];[|'.'; '.'; '#'; '#'; '#'; '.'; '.'; '#'|];[|'.'; '.'; '.'; '#'; '.'; '.'; '#'; '.'|];[|'#'; '#'; '.'; '.'; '.'; '.'; '#'; '.'|];[|'#'; '.'; '.'; '.'; '#'; '.'; '.'; '.'|];[|'#'; '#'; '#'; '.'; '#'; '.'; '.'; '#'|]|] |> should equal 13
