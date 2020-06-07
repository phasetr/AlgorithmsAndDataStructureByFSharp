(*
TODO
https://atcoder.jp/contests/abc169/tasks/abc169_d
http://www4.airnet.ne.jp/tmt/trimmhs/trimg44.pdf
*)

let primeFactors n =
    let intFactors n =
        let sqrtN = 1L + n |> (double >> sqrt) |> int64
        [ for i in 2L .. sqrtN do
            if n % i = 0L then i ]

    let rec pfs n ifs ret =
        match n with
        | 0L -> ret
        | 1L -> ret
        | _ ->
            match ifs with
            | [] -> ret
            | x :: xs ->
                let newifs = if n % (x * x) = 0L then ifs else xs
                let newN = if n % x = 0L then n / x else n
                let newRet = if n % x = 0L then (x :: ret) else ret
                pfs newN newifs newRet

    pfs n (intFactors n) []

let rec divNum n pfs ret =
    match pfs with
    | [] -> ret
    | x :: xs ->
        let newN = n / x
        if newN = 1L then ret else divNum newN xs ret + 1L

divNum 24L (primeFactors 24L) 0L
divNum 1L (primeFactors 1L) 0L
divNum 64L (primeFactors 64L) 0L
divNum 997764507000L (primeFactors 997764507000L) 0L
