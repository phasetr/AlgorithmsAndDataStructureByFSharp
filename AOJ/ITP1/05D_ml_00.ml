let mod3 j = j mod 3 == 0;;
let contain3 j = String.contains (string_of_int j) '3';;
let solve n = for i=1 to n do if (mod3 i || contain3 i) then Printf.printf " %d" i else () done; print_newline();;
let () = let n = read_int() in solve n;;

solve 30;;
