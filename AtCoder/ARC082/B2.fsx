@"https://atcoder.jp/contests/abc072/submissions/13639080"
#r "nuget: FsUnit"
open FsUnit

@"
let N = stdin.ReadLine() |> int
let A = stdin.ReadLine().Split() |> Array.map int |> Array.toList

let rec loop i items count =
    match items with
    | [head] -> if head = i then count + 1 else count
    | head :: [tail] ->
        if head = i
        then loop (i + 1) [head] (count + 1)
        else loop (i + 1) [tail] count
    | head :: sec :: tail ->
        if i = head
        then loop (i + 1) (head::tail) (count + 1)
        else loop (i + 1) (sec::tail) count

loop 1 A 0 |> stdout.WriteLine"
let solve N Pa =
    let A = Pa |> Array.toList
    let rec loop i count = function
        | [head] -> if head=i then count+1 else count
        | head::[tail] ->
            if head = i then loop (i+1) (count+1) [head]
            else loop (i+1) count [tail]
        | head::sec::tail ->
            if i=head then loop (i+1) (count+1) (head::tail)
            else loop (i+1) count (sec::tail)
    loop 1 A 0
let N = stdin.ReadLine() |> int
let Pa = stdin.ReadLine().Split() |> Array.map int
solve N Pa |> stdout.WriteLine

solve 5 [|1;4;3;5;2|] |> should equal 2
solve 2 [|1;2|] |> should equal 1
solve 2 [|2;1|] |> should equal 0
