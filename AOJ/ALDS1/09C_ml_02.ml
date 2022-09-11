(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_C/review/2039388/superluminalsloth/OCaml *)
let swap a i j =
  let temp = a.(i) in
  a.(i) <- a.(j);
  a.(j) <- temp
;;

let i = ref 0;;

let extract (a:int array) =
  Printf.printf "%d\n" a.(0);
  a.(0) <- a.(!i);
  let rec downheap h j =
    let largest = ref j in
    if j*2 <= h then
      begin
        if a.(j*2-1) > a.(j-1) then largest := j*2;
        if j*2+1 <= h && a.(j*2) > a.(!largest-1) then largest := j*2+1;
        if !largest != j then
          begin
            swap a (!largest-1) (j-1);
            downheap h (!largest)
          end
      end
  in downheap !i 1;i := !i-1
;;

let insert (a:int array) n =
  a.(!i+1) <- n;
  let rec upheap j =
    if j = 1 then ()
    else
      begin
        if a.(j/2-1) < a.(j-1) then swap a (j/2-1) (j-1)
        ;upheap (j/2)
      end
  in upheap (!i+2);
     i := !i+1

let () =
  let l = Array.make 2000000 0 in
  let rec read () =
    let op = Scanf.scanf "%s " (fun x -> x) in
    if op = "insert" then
      begin
        let n = Scanf.scanf "%d " (fun x -> x) in
        insert l n;read ()
      end
    else if op = "extract" then begin extract l;read () end
  in read ()
;;
