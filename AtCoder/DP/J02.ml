(*https://atcoder.jp/contests/dp/submissions/4635731*)
open Printf

let n = int_of_string @@ read_line ()
let a =
  Str.split (Str.regexp " ") @@ read_line ()
  |> List.map int_of_string

let cnt = Array.make 4 0
let dp = Array.make (n+1) @@ Array.make_matrix (0) (0) (-1.0)

let rec calc: int -> int -> int -> float = fun i1 i2 i3 ->
  if dp.(i1).(i2).(i3) <> -1.0 then dp.(i1).(i2).(i3)
  else
    let numer =
      (float n)
      +. (if i1 = 0 then 0. else ((float i1) *. calc (i1-1) i2 i3))
      +. (if i2 = 0 then 0. else ((float i2) *. calc (i1+1) (i2-1) i3))
      +. (if i3 = 0 then 0. else ((float i3) *. calc i1 (i2+1) (i3-1))) in
    let denom = float @@ i1 + i2 + i3 in

    let res = numer /. denom in

    dp.(i1).(i2).(i3) <- res ;
    res


let () =
  List.iter (fun x -> cnt.(x) <- cnt.(x) + 1) a ;
  for z = 0 to n do
        dp.(z) <- Array.make_matrix (n+1) (n+1) (-1.0)
      done;
  dp.(0).(0).(0) <- 0.0 ;
  begin
    calc cnt.(1) cnt.(2) cnt.(3)
    |> string_of_float
    |> print_endline
  end
