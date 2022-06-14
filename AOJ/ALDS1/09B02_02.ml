(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_B/review/2012911/superluminalsloth/OCaml *)
let rec max_heapify h (a:int array) j =
  let largest = ref j
  in
  if j*2 <= h then
    begin
      if a.(j*2-1) > a.(j-1) then largest := j*2;
      if j*2+1 <= h && a.(j*2) > a.(!largest-1) then largest := j*2+1;
      if !largest != j then
        begin
          let temp = a.(!largest-1) in
          a.(!largest-1) <- a.(j-1);
          a.(j-1) <- temp;
          max_heapify h a !largest
        end
    end
;;

let build_max_heap h (a:int array) =
  let rec loop = function
      0 -> ()
    | i -> max_heapify h a i;loop (i-1)
  in loop (h/2)
;;

let () =
  let h = read_int () in
  let a = Array.init h (fun _ -> Scanf.scanf " %d" (fun x -> x))
  in
  build_max_heap h a;
  Array.iter (fun x -> print_string " ";print_int x) a;
  print_newline ();;
