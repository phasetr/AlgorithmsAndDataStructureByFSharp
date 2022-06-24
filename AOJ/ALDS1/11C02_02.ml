(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_C/review/2454812/rabbisland/OCaml *)
open Str

let read_list f = split (regexp " +") (read_line ()) |> List.map f

let () =
  let n = read_int () in
  let al = Array.make (n+1) [] in
  let dist = Array.make (n+1) (-1) in
  let q = Queue.create () in
  let rec read x =
    if x = 0 then ()
    else
      begin
        (match read_list int_of_string with
           u :: _ :: vs -> al.(u) <- vs
         | _ -> failwith "read");
        read (x-1)
      end
  in
  let rec loop () =
    if Queue.is_empty q then ()
    else begin
        let u = Queue.pop q in
        List.iter (fun v ->
                   if dist.(v) = (-1) then begin
                       dist.(v) <- dist.(u) + 1;
                       Queue.push v q
                     end
                  ) al.(u);
        loop ()
      end
  in
  read n;
  Queue.push 1 q;
  dist.(1) <- 0;
  loop ();
  Array.iteri (fun i v -> if i > 0 then (string_of_int i) ^ " " ^ (string_of_int v) |> print_endline) dist
