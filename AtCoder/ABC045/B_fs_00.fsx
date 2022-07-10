#r "nuget: FsUnit"
open FsUnit

@"再帰で素直に計算する."
let solve (Sa:string) (Sb:string) (Sc:string) =
    let rec f acc (sa:string) (sb:string) (sc:string) =
        if acc='a' then if sa="" then "A" else f sa.[0] sa.[1..] sb sc
        elif acc='b' then if sb="" then "B" else f sb.[0] sa sb.[1..] sc
        else if sc="" then "C" else f sc.[0] sa sb sc.[1..]
    f 'a' Sa Sb Sc
let Sa = stdin.ReadLine()
let Sb = stdin.ReadLine()
let Sc = stdin.ReadLine()
solve Sa Sb Sc |> stdout.WriteLine

solve "aca" "accc" "ca" |> should equal "A"
solve "abcb" "aacb" "bccc" |> should equal "C"
