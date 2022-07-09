for i in 1..1000 do stdout.WriteLine "Hello World" done
[1..1000] |> List.iter (fun _ -> stdout.WriteLine "Hello World")
