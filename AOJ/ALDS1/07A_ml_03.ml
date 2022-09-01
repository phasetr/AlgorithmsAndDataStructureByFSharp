(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_A/review/5521190/que0/OCaml *)
type rtree = {id: int; pa: int ref ; de: int ref ; ty: string ref; ch: int list}

let n = read_int ()
let a = Array.make n {id = 0; pa = ref 0; de = ref 0;ty = ref ""; ch = []} ;;

for i=0 to n - 1 do
  let tid = Scanf.scanf "%d " (fun x -> x) and tch = ref [] in
  for j = 1 to Scanf.scanf "%d " (fun x -> x) do
    tch := Scanf.scanf "%d " (fun x -> x) :: !tch
  done;
  a.(i) <- {id = tid; pa = ref 0; de = ref 0; ty = ref ""; ch = List.rev !tch}
done;

Array.sort (fun a b -> compare a.id b.id) a;;

let li = List.sort compare (Array.to_list (Array.map (fun x -> x.id) a));;
let lc = List.sort compare (List.flatten (Array.to_list (Array.map (fun x -> x.ch) a)))

let rec wia_wob fa a b =
  match a, b with
  | a, [] -> a
  | [], _ -> []
  | x :: at, y :: bt when fa x = y -> wia_wob fa at bt
  | x :: at, _ :: _ -> x :: wia_wob fa at b

let roots = wia_wob (fun x -> x) li lc;;

let rec bs k fa a b e =
  if e - b <= 0
  then raise Not_found
  else
    let i = (b + e) / 2 in
    match compare k (fa a.(i)) with
    | 0 -> i
    | x when x>0 -> bs k fa a (i+1) e
    | x -> bs k fa a b i;;

let rec rts a i p d = (
    a.(i).pa := p;
    a.(i).de := d;
    a.(i).ty :=
      if p = -1
      then "root"
      else if a.(i).ch = []
      then "leaf"
      else "internal node";
    List.iter
      (fun ci -> rts a (bs ci (fun x -> x.id) a 0 n) a.(i).id (d + 1))
      a.(i).ch );;

List.iter (fun e -> rts a (bs e (fun x -> x.id) a 0 n) (-1) 0) roots;

Array.iter
  (fun e ->
    Printf.printf "node %d: parent = %d, " e.id !(e.pa);
    Printf.printf "depth = %d, %s, [" !(e.de) !(e.ty);
    print_endline @@(String.concat ", " (List.map string_of_int e.ch)) ^ "]")
  a
