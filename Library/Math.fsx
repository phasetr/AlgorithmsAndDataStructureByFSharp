/// 自然数のべき乗
pown 2 3 |> printfn "%d" // 2^3

/// n 進法 n-ary notation
/// 使える文字の都合で n < 26 を仮定するが、本質的ではない
/// 参考：https://webbibouroku.com/Blog/Article/haskell-nstring
/// AtCoder で出てきた「26進数」：AtCoder/ABC171/C1.fsx
module NaryLT16 =
    let numbersLT16 =
        [| "0"
           "1"
           "2"
           "3"
           "4"
           "5"
           "6"
           "7"
           "8"
           "9"
           "a"
           "b"
           "c"
           "d"
           "e"
           "f" |]

    let rec toNary x n =
        if x = 0L then
            []
        else
            let q = x / n
            let r = x % n |> int
            List.append (toNary q n) [ numbersLT16.[r] ]

    let intToNary x n =
        if x = 0L then [ numbersLT16.[0] ]
        elif n = 0L then []
        elif n = 1L then List.replicate (int x) (numbersLT16.[1])
        elif n <= 16L then toNary x n
        else []

//for i in [ 0L; 1L; 2L; 3L; 4L; 5L; 9L; 10L; 11L ] do (NaryLT16.intToNary i 2L |> printfn "%A")

module NaryLT26 =
    let numbersLT26 = [| 'a' .. 'z' |]

    let rec toNary x n =
        if x = 0L then
            []
        else
            let q = x / n
            let r = x % n |> int
            List.append (toNary q n) [ numbersLT26.[r |> int] ]

    let intToNary x n =
        if x = 0L then [ numbersLT26.[0] ]
        elif n = 0L then []
        elif n = 1L then List.replicate (int x) (numbersLT26.[1])
        elif n <= 26L then toNary x n
        else []

for i in [ 0L; 1L; 2L; 3L; 4L; 5L; 9L; 10L; 11L ] do
    (NaryLT26.intToNary i 2L |> printfn "%A")
