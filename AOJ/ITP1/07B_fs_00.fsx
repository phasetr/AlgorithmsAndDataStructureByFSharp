#r "nuget: FsUnit"
open FsUnit

let n,x = 5,9
let solve n x =
  seq { for i in 1..n-2 do for j in i+1..n-1 do for k in j+1..n do if i+j+k=x then yield (i,j,k) }
  |> Seq.length

let n,x = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let rec main() =
  match stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1]) with
    | 0,0 -> ()
    | n,x -> solve n x;; main()

solve 5 9 |> should equal 2
