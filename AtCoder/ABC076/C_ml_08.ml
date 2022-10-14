(* https://atcoder.jp/contests/abc076/submissions/3496724 *)
module SSet = Set.Make(String);;
Scanf.(
  Array.(
    scanf" %s %s" @@
      fun s t->
      let open Printf in
      let k,l = String.length s,String.length t in
      print_endline@@
        if k<l then "UNRESTORABLE"
        else try
            let st = ref SSet.empty in
            for i=0 to k-l do
              (* printf "[%d %d]\n" i (i+l-1); *)
              let f = ref true in
              for j=i to i+l-1 do
                (* printf "  %c  %c\n" s.[j] t.[j-i]; *)
                if s.[j]='?' || s.[j]=t.[j-i] then () else f:=false;
              done;
              if !f then st := SSet.add (
                                   init k (fun j ->
                                       if i<=j && j<=i+l-1 then t.[j-i]
                                       else if s.[j] = '?' then 'a'
                                       else s.[j]
                                     ) |> map (String.make 1) |> Array.to_list |> String.concat ""
                                 ) !st;
            done;
            !st |> SSet.min_elt
          with Not_found -> "UNRESTORABLE"
))
