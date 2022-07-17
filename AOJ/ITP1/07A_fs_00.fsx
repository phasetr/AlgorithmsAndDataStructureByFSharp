#r "nuget: FsUnit"
open FsUnit

let solve m f r =
  let s = m+f
  if m = -1 || f = -1 || s<30 then 'F'
  elif 80 <= s then 'A'
  elif 60 <= s then 'B'
  elif 50 <= s then 'C'
  else if r<50 then 'C' else 'D'
let rec main() =
  match stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2] with
    | (-1,-1,-1) -> ()
    | _ ->
      solve m f r |> stdout.WriteLine
      main()

Array.map (fun (m,f,r) -> solve m f r) [|(40,42,-1);(20,30,-1);(0,2,-1)|] |> should equal [|'A';'C';'F'|]
