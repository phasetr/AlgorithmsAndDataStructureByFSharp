(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_B/review/5524218/que0/OCaml *)
type btree = {id: int; le: int; ri: int; par: int ref ; sie: int ref ;
              deg: int ref ; dep: int ref ; hei: int ref ; typ: string ref}

let n = read_int ()
let a =
  Array.make
    n
    {id = 0; le = 0; ri = 0; par = ref 0; sie = ref 0; deg = ref 0; dep = ref 0; hei = ref 0; typ = ref ""};;

for i= 0 to n - 1 do
  let (d, l, r) = Scanf.scanf "%d %d %d " (fun x y z -> x, y, z) in
  a.(i) <- {id = d; le = l; ri = r; par = ref 0; sie = ref 0; deg = ref 0; dep = ref 0; hei = ref 0; typ = ref ""}
done;

Array.sort (fun a b -> compare a.id b.id) a;;

let li = List.sort compare (Array.to_list (Array.map (fun x -> x.id) a));;
let lc = List.sort compare (List.flatten (Array.to_list (Array.map (fun x -> List.filter (fun x -> x >= 0) [x.le; x.ri]) a)))

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

let rec bts a i p s d = (
    a.(i).par := p;
    a.(i).sie := s;
    a.(i).deg := compare a.(i).le ~-1 + compare a.(i).ri ~-1;
    a.(i).typ :=
      if p = -1
      then "root"
      else if a.(i).le = -1 && a.(i).ri = -1
      then "leaf"
      else "internal node";
    a.(i).dep := d;
    a.(i).hei :=
      max
        (if a.(i).le < 0 then 0 else bts a (bs a.(i).le (fun x -> x.id) a 0 n) a.(i).id  a.(i).ri (d + 1))
        (if a.(i).ri < 0 then 0 else bts a (bs a.(i).ri (fun x -> x.id) a 0 n) a.(i).id  a.(i).le (d + 1));
    !(a.(i).hei) + 1 );;

List.iter (fun e -> ignore @@ bts a (bs e (fun x -> x.id) a 0 n) (-1) (-1) 0) roots;

Array.iter
  (fun e ->
    Printf.printf "node %d: parent = %d, " e.id !(e.par);
    Printf.printf "sibling = %d, degree = %d, " !(e.sie) !(e.deg);
    Printf.printf "depth = %d, height = %d, %s\n" !(e.dep) !(e.hei) !(e.typ); )
  a
