(*https://atcoder.jp/contests/dp/submissions/3940541*)
let memoize n f =
  let dp = Hashtbl.create n in
  let rec get x =
    try Hashtbl.find dp x with
    | Not_found ->
        let result = f get x in
        Hashtbl.add dp x result;
        result in
  get

let () = Scanf.scanf "%d\n" @@ fun n ->
  let hs = Array.init n @@ fun _ -> Scanf.scanf "%d " @@ fun h -> h in
  let cost = memoize n @@ fun cost -> function
    | 0 -> 0
    | 1 -> abs (hs.(0) - hs.(1))
    | i -> min (abs (hs.(i) - hs.(i - 1)) + cost (i - 1)) (abs (hs.(i) - hs.(i - 2)) + cost (i - 2)) in
  Printf.printf "%d\n" @@ cost (n - 1)
