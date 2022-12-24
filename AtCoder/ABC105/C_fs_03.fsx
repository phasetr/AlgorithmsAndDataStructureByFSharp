// https://atcoder.jp/contests/abc105/submissions/8895228
let n = stdin.ReadLine() |> int

// -2進数は実質-2,-1,0,1を数字として持つ4進数と考えられる
let divideMinDigit n :(string * int) =
    match n%4 with
    | 0 -> ("00", n )
    | -3| 1 -> ("01", n-1 )
    | -2| 2 -> ("10", n+2 )
    | -1| 3 -> ("11", n+1 )

let rec strMinus2 (str:string, num) =
    match num with
    | 0 -> if str.Substring(0,1) = "0" then str.Substring(1,str.Length-1) else str
    | _ ->
    divideMinDigit num
    |> (fun (newStr, remainNum) -> strMinus2 (newStr+str, remainNum/4))

if n = 0 then "0" else strMinus2 ("", n)
|> stdout.WriteLine
