(* https://atcoder.jp/contests/tessoku-book/submissions/37363485 *)
 let read_pairs n =
  let x_s = Array.make (n + 1) 0 in
  let y_s = Array.make (n + 1) 0 in
  for i = 1 to n do
    let x, y = Scanf.sscanf (read_line ()) "%d %d" (fun a b -> (a, b)) in
    x_s.(i) <- x;
    y_s.(i) <- y
  done;
  (x_s, y_s)

let input_data () =
  let n = read_int () in
  let x_s, y_s = read_pairs n in
  (n, x_s, y_s)

let distance x_s y_s a b =
  let f_x_a = float_of_int x_s.(a) in
  let f_x_b = float_of_int x_s.(b) in
  let f_y_a = float_of_int y_s.(a) in
  let f_y_b = float_of_int y_s.(b) in
  let x_square = (f_x_a -. f_x_b) *. (f_x_a -. f_x_b) in
  let y_square = (f_y_a -. f_y_b) *. (f_y_a -. f_y_b) in
  sqrt (x_square +. y_square)

let greedy x_s y_s n =
  let currentPlace = ref 1 in
  let visited = Array.make 160 false in
  let visitOrder = Array.make 160 0 in
  visitOrder.(1) <- 1;
  visited.(1) <- true;

  for i = 2 to n do
    let minDist = ref 10000.0 in
    let minID = ref (-1) in

    for j = 1 to n do
      if visited.(j) = false
      then
        (
          let newDist = distance x_s y_s !currentPlace j in
          if !minDist > newDist
          then
            (
              minDist := newDist;
              minID := j
            )
        )
    done;

    visited.(!minID) <- true;
    visitOrder.(i) <- !minID;
    currentPlace := !minID
  done;
  visitOrder.(n + 1) <- 1;
  visitOrder

let () =
  let n, x_s, y_s = input_data () in
  let order = greedy x_s y_s n in
  for i = 1 to n + 1 do
    Printf.printf "%d\n" order.(i)
  done
