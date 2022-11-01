(* https://atcoder.jp/contests/abc113/submissions/3535004 *)
let () =
  Scanf.scanf "%d %d\n" @@
    fun n m ->
    let ps = Array.make n [] in
    for i = 0 to m - 1 do
      Scanf.scanf "%d %d\n" @@ fun p y ->
                               ps.(p - 1) <- (y, i) :: ps.(p - 1)
    done;
    for i = 0 to n - 1 do
      ps.(i) <- List.sort compare ps.(i)
    done;
    List.iter print_endline @@
      List.map snd @@
        List.sort compare @@
          List.concat @@
            Array.to_list @@
              Array.mapi
                (fun p ->
                  List.mapi (fun x (_, i) ->
                      i, Printf.sprintf "%06d%06d" (p + 1) (x + 1))) ps
