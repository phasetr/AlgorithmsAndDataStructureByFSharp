@"https://atcoder.jp/contests/abc145/tasks/abc145_c"
#r "nuget: FsUnit"
open FsUnit

let xs = [0; 1; 2]
cpair N Cs xs
let cs = [((0, 1), (0, 0)); ((0, 0), (1, 0))]
psum cs

let N = 3
let Cs = [|(0,0);(1,0);(0,1)|]
let ps =
    [0..(N-1)] |> perms
    |> List.map (fun xs -> cpair N Cs xs)
ps |> List.map psum |> List.average

[0..(N-1)] |> perms
|> List.map (fun xs -> cpair N Cs xs)
|> List.map psum |> List.average

let solve N Cs =
    let perms xs =
        let rec inserts: 'a -> 'a list -> 'a list list = fun x -> function
            | [] -> [[x]]
            | y::ys -> (x::y::ys) :: List.map (fun z -> y::z) (inserts x ys)
        let step x xss = List.collect (inserts x) xss
        List.foldBack step xs [[]]
    let cpair N (Cs: array<int*int>) (xs: list<int>) =
        [0..(N-2)] |> List.map (fun n -> (Cs.[xs.[n]], Cs.[xs.[n+1]]))
    let sq x = x*x
    let dist (x1,x2) = (sq ((fst x1) - (fst x2))) + (sq ((snd x1) - (snd x2))) |> float |> sqrt
    let psum cs = cs |> List.map dist |> List.sum

    [0..(N-1)] |> perms
    |> List.map (fun xs -> cpair N Cs xs)
    |> List.map psum |> List.average

let N = stdin.ReadLine() |> int
let Cs = [| for i in 1..N do (stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1]) |]
solve N Cs |> stdout.WriteLine

solve 3 [|(0,0);(1,0);(0,1)|] // |> should equal 2.2761423749
solve 2 [|(-879,981);(-866,890)|] // |> should equal 91.9238815543
solve 8 [|(-406,10);(512,859);(494,362);(-955,-475);(128,553);(-986,-885);(763,77);(449,310)|] // |> should equal  7641.9817824387
