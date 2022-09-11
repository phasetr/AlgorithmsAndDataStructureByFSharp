(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_C/review/2446239/rabbisland/OCaml *)
open Str

let read_list () =
  split (regexp " +") (read_line ())

let max_heapify h ar i =
  let swap i j =
    let t = ar.(i) in
    ar.(i) <- ar.(j);
    ar.(j) <- t in
  let rec iter i =
    let l = 2 * i in
    let r = 2 * i + 1 in
    let mi =
      let ti = if l <= h && ar.(l) > ar.(i) then l else i in
      if r <= h && ar.(r) > ar.(ti) then r else ti in
    if mi <> i then
      begin
        swap mi i;
        iter mi
      end
  in
  iter i

let extract h ar =
  let ret = ar.(1) in
  ar.(1) <- ar.(h);
  max_heapify (h-1) ar 1;
  (h-1, ret)

let insert h ar k =
  let swap i j =
    let t = ar.(i) in
    ar.(i) <- ar.(j);
    ar.(j) <- t in
  let rec iter i =
    let p = i / 2 in
    if p = 0 || ar.(p) >= ar.(i) then h+1
    else (swap p i; iter p)
  in
  ar.(h+1) <- k;
  iter (h+1)

let () =
  let pq = Array.make 2000000 0 in
  let rec read h =
    match read_list () with
      "insert" :: n :: _ -> let nh = insert h pq (int_of_string n) in read nh
    | "extract" :: _ -> let (nh, v) = extract h pq in (string_of_int v |> print_endline); read nh
    | "end" :: _ -> ()
    | _ -> failwith "read"
  in
  read 0
