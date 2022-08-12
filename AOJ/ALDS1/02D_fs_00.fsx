#r "nuget: FsUnit"
open FsUnit

let N,Aa = 5,[|5;1;4;3;2|]
let solve N Aa =
  let shellSort (a:int[]) n g count =
    let cnt = ref count
    for i = g to n-1 do
      let v = a.[i] in
      let rec loop j =
        if j < 0 || a.[j] <= v then (j+g)
        else a.[j+g] <- a.[j]; cnt.Value <- cnt.Value+1; loop (j-g)
      in a.[loop (i-g)] <-v
    done
    cnt.Value

  let n = float N
  let rec gen g b =
    let b2 = b * 2.25 + 1.0
    if b2 > n then g else gen ((int (ceil b2))::g) b2
  let g = gen [] 0.0
  let m = List.length g
  let rec loop cnt = function
    | [] -> (m, g, cnt, Aa)
    | h::t -> loop (shellSort Aa N h cnt) t
  loop 0 g

let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do (stdin.ReadLine() |> int) |]
solve N Aa
|> fun (s1,s2,s3,s4) ->
  stdout.WriteLine s1
  s2 |> List.map string |> String.concat " " |> stdout.WriteLine
  stdout.WriteLine s3
  s4 |> Array.iter stdout.WriteLine

solve 5 [|5;1;4;3;2|] |> should equal (2,[4;1],3,[|1..5|])
solve 3 [|3;2;1|] |> should equal (1,[1],3,[|1..3|])
