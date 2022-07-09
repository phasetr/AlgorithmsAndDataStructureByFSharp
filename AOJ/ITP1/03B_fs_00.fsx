#r "nuget: FsUnit"
open FsUnit

let solve n x = sprintf "Case %d: %d" n x
let rec frec n =
    let x = stdin.ReadLine() |> int
    if x = 0 then ()
    else
        solve n x |> stdout.WriteLine
        frec (n+1)
frec 1

[3;5;11;7;8;19;0] |> List.mapi (fun n x -> solve (n+1) x) |> should equal ["Case 1: 3";"Case 2: 5";"Case 3: 11";"Case 4: 7";"Case 5: 8";"Case 6: 19";"Case 7: 0"]
