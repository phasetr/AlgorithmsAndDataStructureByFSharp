#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa = 4,[|(2,3,5);(2,1,5);(1,2,5);(3,2,5)|]
let N,Aa = 2,[|(0,0,100);(1,1,98)|]
let N,Aa = 3,[|(99,1,191);(100,1,192);(99,0,192)|]
*)
let solve Aa =
  let l1 (x1,y1) (x2,y2) = abs(x1-x2) + abs(y1-y2)
  let (x0,y0,h0) = Aa |> Array.find (fun (_,_,h) -> h<>0)
  seq { for x in 0..100 do for y in 0..100 do x,y }
  |> Seq.map (fun (x,y) -> x, y, h0 + l1 (x,y) (x0,y0))
  |> Seq.find (fun (x,y,h) ->
    Aa |> Array.forall (fun (xi,yi,hi) -> hi = max 0 (h - l1 (x,y) (xi,yi))))
  |> fun (x,y,h) -> sprintf "%d %d %d" x y h

let N = stdin.ReadLine() |> int
let Aa = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2])
solve Aa |> stdout.WriteLine

solve [|(2,3,5);(2,1,5);(1,2,5);(3,2,5)|] |> should equal "2 2 6"
solve [|(0,0,100);(1,1,98)|] |> should equal "0 0 100"
solve [|(99,1,191);(100,1,192);(99,0,192)|] |> should equal "100 0 193"
