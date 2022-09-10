(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_B/review/5535224/que0/OCaml *)
let left i = i * 2 + 1
let right i = i * 2 + 2
let a_sw a i j = let b = a.(i) in (a.(i) <- a.(j); a.(j) <- b)

let rec maxHeapify a i n =
  let l = left i and r = right i in
  let largest = (
    if l < n && a.(l) > a.(i)
    then l
    else i ) in
  let largest = (
    if r < n && a.(r) > a.(largest)
    then r
    else largest ) in (
  if largest <> i
  then (
    a_sw a i largest;
    maxHeapify a largest n ) )

let buildMaxHeap i a n =
  for i = (n - 1) / 2 downto 0 do
    maxHeapify a i n
  done

let n = read_int ()
let a = Array.init n (fun _ -> Scanf.scanf "%d " (fun x -> x));;
buildMaxHeap 0 a n;
Array.iter (Printf.printf " %d") a;
print_newline ()
