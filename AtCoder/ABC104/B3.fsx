@"https://atcoder.jp/contests/abc104/submissions/18844232"
#r "nuget: FsUnit"
open FsUnit

let readCharArray () = stdin.ReadLine().ToCharArray()
let choice ok ng bool = if bool then ok else ng

let solve (x: array<char>) =
    (x.[0] = 'A'
     && x.[2..(x.Length - 2)]
     |> Array.filter ((=) 'C')
     |> Array.length
     |> ((=) 1)
     && x
     |> Array.filter System.Char.IsUpper
     |> Array.length
     |> ((=) 2))
    |> choice "AC" "WA"

stdin.ReadLine().ToCharArray() |> solve |> stdout.WriteLine
