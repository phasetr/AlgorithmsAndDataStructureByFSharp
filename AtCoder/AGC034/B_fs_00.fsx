#r "nuget: FsUnit"
open FsUnit

// let S = "ABCABC"
// let solveTLE S =
//   let re = new System.Text.RegularExpressions.Regex("ABC")
//   let rec frec acc (S:string) = if S.Contains("ABC") then frec (acc+1) (re.Replace(S,"BCA",1)) else acc
//   frec 0 S
let solve0 S =
  let rec frec k na xs =
    match (na,xs) with
      | _,[] -> k
      | n,'A'::cs -> frec k (n+1L) cs
      | 0L,'B'::'C'::cs -> frec k 0L cs
      | n,'B'::'C'::cs -> frec (k+n) n cs
      | _,_::cs -> frec k 0L cs
  S |> Seq.toList |> frec 0L 0L

stdin.ReadLine() |> solve0 |> stdout.WriteLine

let solve (S:string) =
  let rec frec k na xs =
    match (na,xs) with
      | _,[] -> k
      | n,'A'::cs -> frec k (n+1L) cs
      | 0L,'D'::cs -> frec k 0L cs
      | n,'D'::cs -> frec (k+n) n cs
      | _,_::cs -> frec k 0L cs
  S.Replace("BC","D") |> Seq.toList |> frec 0L 0L

stdin.ReadLine() |> solve |> stdout.WriteLine

solve "ABCABC" |> should equal 3L
solve "C" |> should equal 0L
solve "ABCACCBABCBCAABCB" |> should equal 6L
