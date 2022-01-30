@"https://atcoder.jp/contests/abc128/submissions/17235021"
#r "nuget: FsUnit"
open FsUnit

let solve N sps =
    sps |> Array.indexed
    |> Array.sortByDescending (fun (_,(_,point)) -> point)
    |> Array.sortBy (fun (_,(city,_)) -> city)
    |> Array.map (fun (idx,_) -> idx + 1)
let N = stdin.ReadLine() |> int
let sps = [| for i in 1..N do (stdin.ReadLine().Split() |> fun x -> x.[0], int x.[1]) |]
solve N sps |> Array.map string |> String.concat "\n" |> stdout.WriteLine

solve 6 [|("khabarovsk",20);("moscow",10);("kazan",50);("kazan",35);("moscow",60);("khabarovsk",40)|] |> should equal [|3;4;6;1;5;2|]
solve 10 [|("yakutsk",10);("yakutsk",20);("yakutsk",30);("yakutsk",40);("yakutsk",50);("yakutsk",60);("yakutsk",70);("yakutsk",80);("yakutsk",90);("yakutsk",100)|] |> should equal [|10;9;8;7;6;5;4;3;2;1|]
