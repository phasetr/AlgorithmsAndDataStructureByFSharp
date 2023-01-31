#r "nuget: FsUnit"
open FsUnit

(*
let N,Ca = 5,[|"#....";"#.#..";"....#";"....#";"...##"|]
*)
let solve N Ca =
  let caps =
    let caps = Array2D.create (2*N+2) (2*N+2) 0
    let a = 2*N
    let b = 2*N+1
    Ca |> array2D |> Array2D.iteri (fun i j c ->
      if c='#' then caps.[i,N+j] <- 1
      caps.[a,i] <- 1
      caps.[N+i,b] <- 1)
    caps
  let searchPath s g =
    let srch = System.Collections.Generic.Queue<int>() |> fun q -> q.Enqueue(s); q
    let bfr = Array.create (2*N+2) (-1) |> fun bfr -> bfr.[s] <- 0; bfr
    let rec frec b =
      if srch.Count = 0 then false
      else
        let i = srch.Dequeue()
        if i=g then true
        else
          for j in 0..(2*N+1) do if bfr.[j]<0 && 0<caps.[i,j] then srch.Enqueue(j); bfr.[j] <- i
          frec b
    (frec false, bfr)
  let updateFlow s g (bfr:int[]) =
    let rec frec c j =
      if j=s then c
      else let i = bfr.[j] in frec (min caps.[i,j] c) i
    let c = frec System.Int32.MaxValue g
    let rec grec j =
      if j<>s then let i = bfr.[j] in caps.[i,j] <- caps.[i,j]-c; caps.[j,i] <- caps.[j,i]+c; grec i
    grec g
    c
  let maxFlow s g =
    let rec frec acc =
      let (b, bfr) = searchPath s g
      if b then frec (acc + updateFlow s g bfr) else acc
    frec 0
  maxFlow (2*N) (2*N+1)

let N = stdin.ReadLine() |> int
let Ca = Array.init N (fun _ -> stdin.ReadLine())
solve N Ca |> stdout.WriteLine

solve 5 [|"#....";"#.#..";"....#";"....#";"...##"|] |> should equal 4
