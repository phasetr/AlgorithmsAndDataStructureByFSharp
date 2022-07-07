let solve sa =
  Array.sort compare sa;
  sa |> Array.to_list |> String.concat "";;
let n,l = Scanf.scanf " %d %d" @@ fun a b -> a, b;;
let sa = Array.init n @@ fun _ -> Scanf.scanf " %s" @@ fun s -> s;;
solve sa |> print_endline;;

solve [|"dxx";"axx";"cxx"|] = "axxcxxdxx";;

