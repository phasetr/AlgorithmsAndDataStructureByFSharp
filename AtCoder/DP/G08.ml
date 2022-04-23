(*https://atcoder.jp/contests/dp/submissions/3949005*)
let memoize n f =
  let dp = Hashtbl.create n in
  let rec get x =
    try Hashtbl.find dp x with
    | Not_found ->
        let result = f get x in
        Hashtbl.add dp x result;
        result in
  get

let () = Scanf.scanf "%d %d\n" @@ fun n m ->
  let es = Array.make n [] in
  for i = 1 to m do
    Scanf.scanf "%d %d\n" @@ fun x y ->
      es.(x - 1) <- y - 1 :: es.(x - 1)
  done;
  let dp = memoize n @@ fun dp v ->
    List.fold_right (fun u -> max @@ 1 + dp u) es.(v) 0 in
  Printf.printf "%d\n" @@ Array.fold_left max min_int @@ Array.init n dp
