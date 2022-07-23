#r "nuget: FsUnit"
open FsUnit

let solve Xs =
  let isAlpha c = (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')
  let input =
    Xs
    |> String.concat ""
    |> Seq.choose (fun c -> if isAlpha c then Some (System.Char.ToLower c) else None)
    |> Seq.groupBy id
    |> Seq.map (fun (c,xs) -> (c,Seq.length xs)) |> Map
  [|'a'..'z'|]
  |> Array.map (fun c -> if Map.containsKey c input then sprintf "%c : %d" c input.[c] else sprintf "%c : 0" c)

let Alls = Console.ReadLine() |> Seq.initInfinite |> Seq.takeWhile ((<>) null)
solve Alls |> Array.iter stdout.WriteLine

let Xs = seq {"This is a pen."}
solve Xs |> should equal [|"a : 1";"b : 0";"c : 0";"d : 0";"e : 1";"f : 0";"g : 0";"h : 1";"i : 2";"j : 0";"k : 0";"l : 0";"m : 0";"n : 1";"o : 0";"p : 1";"q : 0";"r : 0";"s : 2";"t : 1";"u : 0";"v : 0";"w : 0";"x : 0";"y : 0";"z : 0";|]
solve Xs |> Array.iter stdout.WriteLine

let Xs = seq {"ABCD E F Z";"x";"y";"z"}
solve Xs |> should equal [|"a : 1";"b : 1";"c : 1";"d : 1";"e : 1";"f : 1";"g : 0";"h : 0";"i : 0";"j : 0";"k : 0";"l : 0";"m : 0";"n : 0";"o : 0";"p : 0";"q : 0";"r : 0";"s : 0";"t : 0";"u : 0";"v : 0";"w : 0";"x : 1";"y : 1";"z : 2"|]
solve Xs |> Array.iter stdout.WriteLine
