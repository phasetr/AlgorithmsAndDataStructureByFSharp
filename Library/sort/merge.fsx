#r "nuget: FsUnit"
open FsUnit

// https://gist.github.com/JohnThomson/b4697166d769fe3dbbf0
// tail recursive version
module Merge1 =
  let rec revcat r = function
    | [] -> r
    | b::t -> revcat (b::r) t

  let rec merge s1 s2 =
    let rec help acc = function
      | [],[] -> acc
      | [],rs -> revcat rs acc
      | ls,[] -> revcat ls acc
      | h1::t1, h2::t2 when h1 < h2 -> help (h1::acc) (t1,(h2::t2))
      | ls, h2::t2 -> help (h2::acc) (ls,t2)
    revcat (help [] (s1,s2)) []

  let bisect w =
    let rec help r l = function
      | [] -> (r,l)
      | [x] -> (x::r,l)
      | x::y::t -> help (x::r) (y::l) t
    help [] [] w

  let rec msort = function
    | [] -> []
    | [x] -> [x]
    | w ->
      let l,r = bisect w
      merge (msort l) (msort r)

  // TEST
  let lst = [1;8;7;6;2;5;9;4;0;3]
  let l,r = bisect lst
  revcat r l |> should equal [1;7;2;9;0;3;4;5;6;8]
  bisect lst |> should equal ([0;9;2;7;1],[3;4;5;6;8])
  merge l r |> should equal [0;3;4;5;6;8;9;2;7;1]
  msort lst |> should equal  [0..9]

  // 大きなリストに対してスタックオーバーフローしないか?
  let genRandomNumbers count =
    let rnd = System.Random()
    List.init count (fun _ -> rnd.Next (100000))
  msort (genRandomNumbers 1000000)
