(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_B/review/2453898/rabbisland/OCaml *)
open Str

let read_list f = split (regexp " +") (read_line ()) |> List.map f

let () =
  let n = read_int () in
  let al = Array.make (n+1) [] in
  let vt = Array.make (n+1) true in
  let rec read x =
    if x = 0 then ()
    else begin
        (match read_list int_of_string with
           u :: _ :: vs -> al.(u) <- vs
         | _ -> failwith "read");
        read (x-1)
      end
  in
  let rec dfs (t, ls) i =
    if vt.(i) then begin
      vt.(i) <- false;
      let (t', ls') = List.fold_left dfs (t+1, ls) al.(i) in
      (t'+1 , (i, t, t') :: ls')
      end
    else (t, ls)
  in
  let rec loop (t, ls) i =
    if i > n then ls
    else
      if vt.(i)
      then let (t', ls') = dfs (t, ls) i in loop (t', ls') (i+1)
      else loop (t, ls) (i+1)
  in
  read n;
  loop (1,[]) 1 |> List.sort compare |>
    List.iter (fun (x, y, z) -> (string_of_int x) ^ " " ^ (string_of_int y) ^ " " ^ (string_of_int z) |> print_endline)
