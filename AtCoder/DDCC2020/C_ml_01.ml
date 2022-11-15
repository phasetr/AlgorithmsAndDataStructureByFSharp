(* https://atcoder.jp/contests/ddcc2020-qual/submissions/8587243 *)
let () = Scanf.scanf "%d %d %d\n" @@ fun h w k ->
  let ss = Array.init h @@ fun _ ->
    Scanf.scanf "%s\n" @@ fun s -> s in
  let draw cnt s =
    let cakes = ref 0 in
    String.iter (fun c ->
      if c = '#' then incr cakes;
      Printf.printf "%d " (cnt + max 0 (!cakes - 1))) s;
    print_newline ();
    !cakes in
  let cnt = ref 1 in
  let rec solve' s cakes i =
    if i < h then begin
      let s =
        if
          List.for_all (( = ) '.') @@
          Array.to_list @@
          Array.init (String.length ss.(i)) (String.get ss.(i))
        then s
        else (cnt := cakes + !cnt; ss.(i)) in
      solve' s (draw !cnt s) (i + 1)
    end in
  let rec solve i =
    if
      List.for_all (( = ) '.') @@
      Array.to_list @@
      Array.init (String.length ss.(i)) (String.get ss.(i))
    then solve (i + 1)
    else begin
      for j = 0 to i - 1 do
        draw 1 ss.(i)
      done;
      solve' ss.(i) 0 i
    end in
  solve 0;
