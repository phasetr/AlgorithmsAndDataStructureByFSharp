#r "nuget: FsUnit"
open FsUnit

(*
let N,Ia = 5,[|(2,8);(4,-5);(5,-3);(-4,1);(-2,-3)|]
*)
let solve N Ia =
  let (.+.) ((a,b):int64*int64) (c,d) = (a+c,b+d)
  (((0L,0L),(0L,0L),(0L,0L),(0L,0L)), Ia)
  ||> Array.fold (fun (t0,t1,t2,t3) (a,b) ->
    let u0 = if a+b>0L then t0 .+. (a,b) else t0
    let u1 = if a-b>0L then t1 .+. (a,-b) else t1
    let u2 = if b-a>0L then t2 .+. (-a,b) else t2
    let u3 = if a+b<0L then t3 .+. (-a,-b) else t3
    (u0,u1,u2,u3))
  |> fun ((a0,b0),(a1,b1),(a2,b2),(a3,b3)) -> List.max [a0+b0;a1+b1;a2+b2;a3+b3]
let N = stdin.ReadLine() |> int
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int64 |> fun x -> x.[0],x.[1])
solve N Ia |> stdout.WriteLine

solve 5 [|(2L,8L);(4L,-5L);(5L,-3L);(-4L,1L);(-2L,-3L)|] |> should equal 18L
