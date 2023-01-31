#r "nuget: FsUnit"
open FsUnit

(*
let N,Ca = 5,[|"#....";"#.#..";"....#";"....#";"...##"|]
*)
let solve N Ca =
  let es =
    let es = Array.init (2*N) (fun _ -> [])
    Ca |> array2D |> Array2D.iteri (fun i j c ->
      if c='#' then es.[i] <- (j+N)::es.[i]; es.[j+N] <- i::es.[j+N])
    es
  let matched = Array.create (2*N) (-1)
  let rec dfs v (used:bool[]) =
    used.[v] <- true
    let rec frec = function
      | [] -> false
      | u::t ->
        let w = matched.[u]
        if w<0 || not used.[w] && dfs w used then matched.[v] <- u; matched.[u] <- v; true
        else frec t
    frec es.[v]
  (0,[|0..2*N-1|]) ||> Array.fold (fun x v ->
    let used = Array.create (2*N) false
    if matched.[v]<0 && (dfs v used) then x+1 else x)

let N = stdin.ReadLine() |> int
let Ca = Array.init N (fun _ -> stdin.ReadLine())
solve N Ca |> stdout.WriteLine

solve 5 [|"#....";"#.#..";"....#";"....#";"...##"|] |> should equal 4
