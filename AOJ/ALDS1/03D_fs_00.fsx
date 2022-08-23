#r "nuget: FsUnit"
open FsUnit

let solve S =
  let span p xs = (List.takeWhile p xs, List.skipWhile p xs)
  let rec help: (int*char) list -> (int*int) list -> (int*char) list -> int list = fun ds ps ys ->
    match (ds,ps,ys) with
      | (_, ps, []: (int*char) list) -> List.map snd (List.rev ps)
      | (ds, ps, ((n,'\\') as x)::xs) -> help (x::ds) ps xs
      | ([], ps, ((n,'/') as x)::xs) -> help [] ps xs
      | ((m,_)::ds, ps, ((n,'/') as x)::xs) ->
        let (pl,pr) = span (fun p -> m <= (fst p)) ps
        let newp = (n, (n-m) + List.sum (List.map snd pl))
        help ds (newp::pr) xs
      | (ds, ps, x::xs) -> help ds ps xs
  help [] [] (List.zip [0..(Seq.length S)-1] (Seq.toList S))

let S = stdin.ReadLine()
let solution = solve S
List.sum solution |> stdout.WriteLine
List.length @ solution |> String.concat " " |> stdout.WriteLine

solve @"\\//" |> should equal [4]
solve @"\\///\_/\/\\\\/_/\\///__\\\_\\/_\/_/\" |> should equal [4;2;1;19;9]
