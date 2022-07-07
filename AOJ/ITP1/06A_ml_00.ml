let solve xs = xs |> List.rev |> String.concat " ";;
read_int() |> ignore;
read_line() |> Str.split (Str.regexp " ") |> solve |> print_endline;;

solve ["1";"2";"3";"4";"5"] = "5 4 3 2 1";;
solve ["3";"3";"4";"4";"5";"8";"7";"9"] = "9 7 8 5 4 4 3 3";;

