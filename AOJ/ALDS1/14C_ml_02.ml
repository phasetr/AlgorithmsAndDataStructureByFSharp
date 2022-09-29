(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_C/review/2456819/r6eve/OCaml *)
let (p1, p2, p3) = (257, 251, 1000000007)

let split_on_char sep s =
  let open String in
  let r = ref [] in
  let j = ref (length s) in
  for i = length s - 1 downto 0 do
    if get s i = sep then begin
        r := sub s (i + 1) (!j - i - 1) :: !r;
        j := i
      end
  done;
  sub s 0 !j :: !r

let pow x n =
  let rec doit x n acc =
    if n = 0 then acc
    else if n mod 2 = 0 then doit (x * x mod p3) (n / 2) acc
    else doit (x * x mod p3) (n / 2) (acc * x mod p3) in
  doit x n 1

let make_hash v (x, y) (r, c) =
  let h1 = Array.make_matrix x y 0 in
  let c1 = pow p1 c in
  for i = 0 to x - 1 do
    let rec aux j acc =
      if j = c then acc
      else aux (j + 1) ((acc*p1 + Char.code v.(i).(j)) mod p3) in
    let rec doit j z =
      if j = y - c then h1.(i).(j) <- z
      else begin
          h1.(i).(j) <- z;
          let z = (z*p1 - (Char.code v.(i).(j))*c1 + Char.code v.(i).(j+c)) mod p3 in
          doit (j + 1) (if z < 0 then z + p3 else z)
        end in
    aux 0 0 |> doit 0;
  done;
  let h2 = Array.make_matrix x y 0 in
  let c2 = pow p2 r in
  for j = 0 to y - 1 do
    let rec aux i acc =
      if i = r then acc
      else aux (i + 1) ((acc*p2 + h1.(i).(j)) mod p3) in
    let rec doit i z =
      if i = x - r then h2.(i).(j) <- z
      else begin
          h2.(i).(j) <- z;
          let z = (z*p2 - h1.(i).(j)*c2 + h1.(i+r).(j)) mod p3 in
          doit (i + 1) (if z < 0 then z + p3 else z)
        end in
    aux 0 0 |> doit 0;
  done;
  h2

let solve (h, w) (r, c) a b =
  let s = make_hash a (h, w) (r, c) in
  let t = make_hash b (r, c) (r, c) in
  for i = 0 to h - r do
    for j = 0 to w -c do
      if s.(i).(j) = t.(0).(0) then Printf.printf "%d %d\n" i j;
    done
  done

let read_array x y =
  let a = Array.make_matrix x y '\000' in
  for i = 0 to x - 1 do
    let l = read_line () in
    for j = 0 to y - 1 do
      a.(i).(j) <- l.[j];
    done
  done;
  a

let () =
  match read_line () |> split_on_char ' ' |> List.map int_of_string with
  | [h; w] ->
     begin
       let a = read_array h w in
       match read_line () |> split_on_char ' ' |> List.map int_of_string with
       | [r; c] ->
          if h < r || w < c then ()
          else read_array r c |> solve (h, w) (r, c) a
       | _ -> assert false
     end
  | _ -> assert false
