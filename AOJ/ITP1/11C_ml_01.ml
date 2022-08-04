(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_C/review/4034403/Wasedadaigaku/OCaml *)
let () =
  let read_dice () = Scanf.sscanf (read_line ()) "%d %d %d %d %d %d" (fun a b c d e f ->  [(a,f) ;(b,e) ;(c,d) ] ) in
  let faces1 = read_dice () in
  let faces2 = read_dice () in
  let scan faces2 bop =
    let r1,r2 =
      List.fold_left2 (
          fun (r1,r2) (a,b) (c,d) ->
          let b1,b2 = (a = c && b = d), (a = d && b = c) in
          if b1 && b2 then 1, true
          else if b1 then 1 * r1, r2
          else if b2 then -1 * r1, r2
          else 0, false
        ) (1,false) faces1 faces2
    in
    bop r1 0 || (r1 <> 0 && r2 )
  in
  let rec loop faces2 bop = function
    | 0 -> false
    | i -> scan faces2 bop || let faces2' =
                                (List.tl faces2) @ [(List.hd faces2)] in
                              loop faces2' bop (i-1)
  in
  print_string
  @@ if loop faces2 (>) 3 || loop (List.rev faces2) (<) 3 then "Yes\n"
     else "No\n"
