(*
let N = 2L
let N = 3485L
let N = 4664L
*)
let solve N =
  let rec frec h k =
    let d = 4L*h*k - N*(k+h)
    if d>0L && (N*h*k)%d=0L then (h,k,(N*h*k)/d)
    elif k<h then frec h (k+1L)
    else frec (h+1L) 1L
  frec 1L 1L

let N = stdin.ReadLine() |> int64
solve N |> fun (h,k,w) -> printfn "%d %d %d" h k w

(*
solve 2L |> fun (h,n,k) -> 4L*h*n*k = 2L*(h*n+n*k+k*h)
solve 3485L |> fun (h,n,k) -> 4L*h*n*k = 3485L*(h*n+n*k+k*h)
solve 4664L |> fun (h,n,k) -> 4L*h*n*k = 4664L*(h*n+n*k+k*h)
*)
