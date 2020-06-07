(*
https://atcoder.jp/contests/abc049/tasks/arc065_a
https://qiita.com/kuuso1/items/606b75c172cafa1d07f6#%E7%AC%AC-9-%E5%95%8F-abc-049-c---daydream
*)

// 後ろからマッチさせていく
let substr (s: string) =
    if s.Substring(s.Length - 5) = "dream" then Some(s.Substring(0, s.Length - 5))
    elif s.Substring(s.Length - 5) = "erase" then Some(s.Substring(0, s.Length - 5))
    elif s.Substring(s.Length - 6) = "eraser" then Some(s.Substring(0, s.Length - 6))
    elif s.Substring(s.Length - 7) = "dreamer" then Some(s.Substring(0, s.Length - 7))
    elif s = "" then Some("")
    else None

let rec fc s =
    match substr s with
    | Some x ->
        match x with
        | "" -> "YES"
        | _ -> fc x
    | _ -> "NO"

let test () =
    fc "erasedream" |> printfn "%s"
    fc "dreameraser" |> printfn "%s"
    fc "dreamerer" |> printfn "%s"

test ()

let main () = stdin.ReadLine() |> fc |> printfn "%s"

main()
