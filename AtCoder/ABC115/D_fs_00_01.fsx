#r "nuget: FsUnit"
open FsUnit

// let N,X = 2,7L
// let N,X = 1,5L
let solve N X =
  let Ba = (1L,[|0..50|]) ||> Array.scan (fun acc _ -> 2L*acc+3L)
  let Pa = (1L,[|0..50|]) ||> Array.scan (fun acc _ -> 2L*acc+1L)
  let rec frec n x =
    if x<=0L then 0L
    elif n=0 then 1L
    elif x<=1L+Ba.[(int n)-1] then frec (n-1) (x-1L)
    else Pa.[n-1] + 1L + frec (n-1) (x-2L-Ba.[n-1])
  frec N X

let N,X = stdin.ReadLine().Split() |> (fun x -> int x.[0], int64 x.[1])
solve N X |> stdout.WriteLine

let rec burger N acc = if N<=0 then acc else burger (N-1) ("B"+acc+"P"+acc+"B")
burger 0 "P" |> should equal "P"
burger 1 "P" |> should equal "BPPPB"
burger 2 "P" |> should equal "BBPPPBPBPPPBB"

solve 2 7L |> should equal 4L
solve 1 1L |> should equal 0L
solve 50 4321098765432109L |> should equal 2160549382716056L

solve 1 5L |> should equal 3L
