(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_B/review/2450660/r6eve/OCaml *)
let area =
  [| [1;3];[0;2;4];[1;5]
     ;[0;4;6];[1;3;5;7];[2;4;8]
     ;[3;7];[4;6;8];[5;7] |]

let md = Array.make_matrix 9 9 0

let initialize_md () =
  for i = 0 to 7 do
    for j = 0 to 8 do
      md.(i+1).(j) <- abs (i / 3 - j / 3) + abs (i mod 3 - j mod 3)
    done
  done

let idastar a limit space_i lower goal =
  let rec doit i space_i moved lower =
    if i = limit then begin
        if a = goal then begin
            List.length moved - 1 |> Printf.printf "%d\n";exit 0
          end;
      end else
      List.iter (fun j ->
          let x = a.(j) in
          if x = List.hd moved then () else
            let lower = lower - md.(x).(j) + md.(x).(space_i) in
            if lower + i > limit then ()
            else begin
                a.(j) <- 0;
                a.(space_i) <- x;
                doit (i + 1) j (x :: moved) lower;
                a.(j) <- x;
                a.(space_i) <- 0;
              end) area.(space_i) in
  doit 0 space_i [-1] lower

let () =
  initialize_md ();
  let a = Array.init 9 (fun _ -> Scanf.scanf "%d " (fun i -> i)) in
  let rec f i =
    if i = 9 then assert false
    else if a.(i) = 0 then i
    else f (i+1) in
  let space_i = f 0 in
  let rec g i acc =
    if i = 9 then acc
    else g (i + 1) (acc + md.(a.(i)).(i)) in
  let lower = g 0 0 in
  let goal = [|1;2;3;4;5;6;7;8;0|] in
  for limit = lower to 31 do
    idastar a limit space_i lower goal;
  done
