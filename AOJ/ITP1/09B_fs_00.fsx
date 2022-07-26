#r "nuget: FsUnit"
open FsUnit

let solve S ha =
  let s = S |> Seq.toList
  (s,ha)
  ||> Array.fold (fun s h -> List.skip h s @ List.take h s)
  |> List.map string |> String.concat ""

let main () =
  match stdid.ReadLine() with
    | "-" -> ()
    | S ->
      let m = stdin.ReadLine() |> int
      let ha = [| for i in 1..m do (stdin.ReadLine() |> int) |]
      solve S ha |> stdout.WriteLine
      main ()

solve "aabc" [|1;2;1|] |> should equal "aabc"
solve "vwxyz" [|3;4|] |> should equal "xyzvw"
