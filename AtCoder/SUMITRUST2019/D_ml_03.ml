(* https://atcoder.jp/contests/sumitrust2019/submissions/8815109 *)
let () = Scanf.scanf "%d\n%s" @@ fun n s ->
  let dp =
    [| Array.make 10 0;
       Array.make 100 0;
       Array.make 1000 0 |] in
  for i = 0 to n - 1 do
    let d0 = Char.code s.[i] - Char.code '0' in
    for d21 = 0 to 99 do
      dp.(2).(10 * d21 + d0) <- dp.(1).(d21) lor dp.(2).(10 * d21 + d0)
    done;
    for d1 = 0 to 9 do
      dp.(1).(10 * d1 + d0) <- dp.(0).(d1) lor dp.(1).(10 * d1 + d0)
    done;
    dp.(0).(d0) <- 1
  done;
  Printf.printf "%d\n" @@
  Array.fold_left ( + ) 0 dp.(2)
