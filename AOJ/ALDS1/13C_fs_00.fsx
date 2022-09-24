#r "nuget: FsUnit"
open FsUnit

// cf. 13C_ml_01.ml
type state = {h: int; sp: int; bd: int array}
let solve Aa =
  let n = 4
  let mutable isp = Array.findIndex ((=) 0) Aa
  let dist bd =
    ((0,0), bd)
    ||> Array.fold
      (fun (i,d) x ->
        if x=0 then (i+1, d)
        else
          let r,c = (i/n, i%n)
          let y = x-1
          let r',c' = (y/n, y%n)
          (i+1, d + abs (r-r') + abs (c-c'))) |> snd
  let rec dfs st d pd limit =
    if st.h = 0 then Some d
    else if d + st.h > limit then None
    else
      (None, [(1,0);(0,1);(-1,0);(0,-1)])
      ||> List.fold
        (fun v (dx, dy) ->
          match v with
          | Some _ -> v
          | None ->
             let x, y = (st.sp/n, st.sp%n)
             let nx, ny = (dx+x, dy+y)
             let npd = 2*dx+dy
             if 0 <= nx && nx < n && 0 <= ny && ny < n && npd + pd <> 0 then
               let nsp = n * nx + ny
               let nbd = Array.copy st.bd
               nbd.[st.sp] <- st.bd.[nsp]
               nbd.[nsp] <- 0;
               let nst = {h = dist nbd; sp = nsp; bd = nbd}
               dfs nst (d+1) npd limit
             else None)
  let rec loop st limit =
    if limit = 100 then failwith "15 puzzle"
    else
      match dfs st 0 0 limit with
      | None -> loop st (limit+1)
      | Some x -> x
  let ih = dist Aa
  loop {h=ih; sp=isp; bd=Aa} ih

let Aa = [| for i in 1..4 do (stdin.ReadLine().Split |> Array.map int) |] |> Array.concat
solve Aa |> stdout.WriteLine

let Aa = [|[|1;2;3;4|];[|6;7;8;0|];[|5;10;11;12|];[|9;13;14;15|]|] |> Array.concat
solve Aa |> should equal 8
