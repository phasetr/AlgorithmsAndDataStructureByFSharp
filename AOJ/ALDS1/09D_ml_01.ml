(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_D/review/5554741/que0/OCaml *)
(* 二進桁数 改良版 *)

let bd65536 =
  Array.concat @@
    [|0;1;2;2;3;3;3;3;4;4;4;4;4;4;4;4|]
    ::
      Array.to_list (
          Array.init
            12
            (fun x -> Array.make (1 lsl (x + 4)) (x + 5)) )

let bin_digs n =
  let n = abs n in
  let rec b_d n byte_pos =
    if n<65536
    then bd65536.(n) + byte_pos
    else b_d (n asr 16) (16 + byte_pos) in
  b_d n 0

(*
   配列添字逆展開。子ヒープ展開の際に、参照に使用する。
   展開後データは1開始なので配列長さがその分大きい
 *)
let a_i_rev1 ah =
  let ar = Array.make (Array.length ah + 1) 0 in
  Array.iteri (fun i x -> ar.(x) <- i) ah;
  ar

(*
   配列添字逆展開。子ヒープ展開の際に、参照に使用する。長さ指定。
   展開後データは1開始なので配列長さがその分大きい
 *)
let a_i_rev1n ah n = (
    let ar = Array.make (n + 1) 0 in
    for i = 0 to n - 1 do
      ar.(ah.(i)) <- i;
    done;
    ar )

let left_c p = 2 * p + 1
let right_c p = 2 * p + 2

(* ある点のヒープ深さ *)
let point_depth n = bin_digs (n + 1)

(*
   ヒープの右端の深さ（浅い方、対称部分の深さ）
   と、左端の深さ（深い方、非対称でもよい最深））
   引数は0なし点数（最後の点の添え字）
 *)
let ri_depth n_woz = point_depth n_woz - 1
let le_depth = bin_digs

(* 対称ヒープの点数、左下点、右下点。引数は深さ *)
let n_symheap d = 1 lsl d - 1
let btle_symheap d = n_symheap (d - 1)
let btri_symheap d = n_symheap d - 1

(* ヒープが対照かどうか、引数は点数（0なし） *)
let is_sym n = n = n_symheap (le_depth n)

(*
   子ヒープの頂点と子ヒープの点の順序（位置）から
   親ヒープの点の順序（位置）を求める
 *)
let pp_of_cp c_top c_pos =
  (1 lsl (bin_digs (c_pos + 1) - 1)) * c_top + c_pos


(*
   子ヒープ直上から親ヒープ頂点までの経路上の位置とデータを得る。リストを作って返す。
 *)
let get_pair_ct_to_pt heap c_top =
  let rec ct_to_pt i =
    if i<= 0
    then []
    else let ii = (i - 1) /2 in (ii, heap.(ii)) :: ct_to_pt ii in
  List.split (ct_to_pt c_top)

(*
   子ヒープを求める。引数は親ヒープの点数（0なし）と子ヒープの頂点
   返すものは、対称かどうか、左深さ、点数、左位置（子ヒープ中））
 *)
let c_heap np ct =
  if np <= ct then raise (Failure ("c_heap " ^ string_of_int np ^ " " ^string_of_int ct))
  else
    let dp = le_depth np in
    let dct = point_depth ct in
    let dc_max = dp - dct + 1 in
    let btleccm = btle_symheap dc_max and btriccm = btri_symheap dc_max in
    let btlecm = pp_of_cp ct btleccm and btricm = pp_of_cp ct btriccm in
    let lpp = np - 1 in
    if lpp < btlecm
    then (true, dc_max - 1)
    else if lpp < btricm
    then (false, dc_max)
    else (true, dc_max)

(*
   子ヒープ拡大用の補充データを得る
   親ヒープはリスト、そのあとはストリームなので、ストリームにしておく。
   計算の重複を減らすことを考えて、ついでに子ヒープ直上の経路も返す。
 *)
let get_supp heap c_top src_strm =
  let (path_supp, elm_supp) = get_pair_ct_to_pt heap c_top in
  let supp_heap = (Stream.of_list (elm_supp)) in
  let flag = ref true in
  let strm1 =
    Stream.from
      (fun _ ->
        try
          if !flag
          then Some (Stream.next supp_heap)
          else Some (Stream.next src_strm)
        with Stream.Failure -> (
          flag := false;
          Some (Stream.next src_strm) ) ) in
  (strm1, path_supp)

(*
   子ヒープを拡大する。子ヒープは対称で最終ヒープに収まるものに限る。
   親ヒープ、子ヒープ頂点、展開前深さ、対照表２個、元ストリームを渡す
   対照表は、拡大前は逆展開、拡大後も逆展開のもの。
   。*)
let expand_c_heap heap ct ds trs trd src_strm =
  let (supp_strm, path_supp) = get_supp heap ct src_strm in (
      for i = 1 to btri_symheap ds + 1 do
        heap.(pp_of_cp ct trd.(i)) <- heap.(pp_of_cp ct trs.(i))
      done;
      for i = btri_symheap ds + 2 to btri_symheap (ds + 1)+1 do
        heap.(pp_of_cp ct trd.(i)) <- Stream.next supp_strm
      done;
      List.iter (fun x -> heap.(x) <- Stream.next supp_strm; ) path_supp;
      heap )

(* ヒープを1から対称形の最大まで拡大する *)
let maximize_sym_heap heap dmax dcurr src_strm heap_rev =
  let rec exp_d1 heap d =
    if d >= dmax
    then heap
    else (
      ignore @@ expand_c_heap heap 1 (d - 1) heap_rev.(d - 1) heap_rev.(d) src_strm;
      ignore @@ expand_c_heap heap 2 (d - 1) heap_rev.(d - 1) heap_rev.(d) src_strm;
      heap_rev.(d + 1) <- a_i_rev1n heap (n_symheap (d + 1));
      exp_d1 heap (d + 1) ) in
  exp_d1 heap dcurr

(*
   拡大した対称ヒープを、与えられたヒープに合わせて部分拡大。
   引数：与えられたヒープの点数、拡大したヒープ、その深さ（対称のはず）、子ヒープ頂点
   内側の関数の戻り値は拡大したかどうかのbool。（拡大なければその時点で成形完了）
   入れ子にして外関数でheapを返して疑似的に関数型にした。
 *)
let shape_heap npg heap dp ct src_strm heap_rev =
  let rec shp_h npg heap dp ct src_strm =
    let is_sym, dl = c_heap npg ct in (
        if is_sym
        then
          let dct = point_depth ct in
          let c_heap_end = dl + dct - 1 in
          if dp <c_heap_end
          then
            let dc = dp - dct + 1 in (
                ignore @@ expand_c_heap heap ct dc heap_rev.(dc) heap_rev.(dc+1) src_strm;
                true )
          else false
        else
          let exped1 = shp_h npg heap dp (left_c ct) src_strm in
          if exped1
          then
            let rc = right_c ct in
            if rc < npg
            then shp_h npg heap dp (right_c ct) src_strm
            else false
          else false
      ) in (
      ignore @@ shp_h npg heap dp ct src_strm;
      heap )

(*
   与えられたデータより１つ少ない要素数のヒープを作る。
   要素は1からの連番。
   n データ数（読み込みデータ、つまりゼロあり）
   d1 深さ（浅い方）
 *)
let make_heap n =
  let heap = Array.make n 0 in
  if n = 1
  then heap
  else
    let src_strm = Stream.from (fun x -> Some (x + 2)) in
    let d1 = le_depth n in
    let heap_rev = Array.make (d1 + 1) [||] in (
        heap.(0) <- 1;
        heap_rev.(1) <- a_i_rev1 [|1|];
        let dmax = ri_depth (n - 1) and dcurr = 1 in
        let heap = maximize_sym_heap heap dmax dcurr src_strm heap_rev in
        let npg = n - 1 and dp = dmax and ct = 0 in
        let heap = shape_heap npg heap dp ct src_strm heap_rev in
        heap )

let n = read_int ()
let ag = Array.init n (fun _ -> Scanf.scanf "%d " (fun x -> x));;

let dmax =1000000000
let divn = 1 lsl 17
let divt = Array.make (dmax / divn + 1) [];;
Array.iter (fun x -> let i = x / divn in divt.(i) <- x :: divt.(i)) ag;;
let sortt = Array.map (fun l -> let ta = (Array.of_list l) in (Array.fast_sort compare ta; ta)) divt
let ag = Array.concat (Array.to_list sortt)

let heap = make_heap n;;
let buf = Buffer.create 9999;;
Printf.bprintf buf "%d" ag.(heap.(0));
for i = 1 to n - 1 do
  Printf.bprintf buf " %d" ag.(heap.(i))
done;
print_string (Buffer.contents buf);
print_newline ()
