#r "nuget: FsUnit"
open FsUnit

let solve a b c d e f command =
  let rec roll a b c d e f = function
    | [] -> a
    | hd::tl ->
      match hd with
        | 'E' -> roll d b a f e c tl
        | 'W' -> roll c b f a e d tl
        | 'S' -> roll e a c d f b tl
        | _   -> roll b f c d a e tl // 'N'
  roll a b c d e f command

let [|a;b;c;d;e;f|] = stdin.ReadLine().Split() |> Array.map int
let command = stdin.ReadLine() |> Seq.toList
solve a b c d e f command |> stdout.WriteLine

let (a,b,c,d,e,f) = 1,2,4,8,16,32
solve a b c d e f ['S';'E'] |> should equal 8
solve a b c d e f ['E';'E';'S';'W';'N'] |> should equal 32
