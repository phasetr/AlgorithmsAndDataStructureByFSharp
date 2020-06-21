(*
delete: Haskell の delete と同じ
https://hackage.haskell.org/package/base-4.14.0.0/docs/Data-List.html#v:delete
*)

let rec delete x xs =
    match xs with
    | [] -> []
    | y :: ys -> if x = y then ys else y :: delete x ys

delete 1 [ 1; 2; 3 ] |> printfn "%A"
delete 4 [ 1; 2; 3 ] |> printfn "%A"

let rec deleteAll x = List.filter ((<>) x)

deleteAll 1 [ 1; 2; 3; 1; 1; 2; 3 ]
|> printfn "%A"

deleteAll 4 [ 1; 2; 3; 1; 1; 2; 3 ]
|> printfn "%A"

(*
takeWhile: Haskell の takeWhile と同じ
https://hackage.haskell.org/package/base-4.14.0.0/docs/Data-List.html#v:takeWhile
下の例では不等号の向きに注意しよう：意図通りか実際に REPL で確かめるのがベスト
takeWhile ((>) 3) [1; 2; 3; 4; 1; 2; 3; 4] = [1; 2]
takeWhile ((>) 9) [1; 2; 3] = [1; 2; 3]
takeWhile ((>) 0) [1; 2; 3] = []
*)

let rec takeWhile (p: 'a -> bool) lst =
    match lst with
    | [] -> []
    | x :: xs -> if p x then x :: takeWhile p xs else []

(*
dropWhile: Haskell の dropWhile と同じ
https://hackage.haskell.org/package/base-4.14.0.0/docs/Data-List.html#v:dropWhile
下の例では不等号の向きに注意しよう：意図通りか実際に REPL で確かめるのがベスト
dropWhile ((>) 3) [1; 2; 3; 4; 5; 1; 2; 3] = [3; 4; 5; 1; 2; 3]
dropWhile ((>) 9) [1; 2; 3] |> List.isEmpty
dropWhile ((>) 0) [1; 2; 3] = [1; 2; 3]
*)

let rec dropWhile (p: 'a -> bool) lst =
    match lst with
    | [] -> []
    | x :: xs -> if p x then dropWhile p xs else lst

(*
span: Haskell の span と同じ
`span p xs = (takeWhile p xs, dropWhile p xs)` であることに注意。
https://hackage.haskell.org/package/base-4.14.0.0/docs/src/GHC.List.html#span
span ((>) 3) [1; 2; 3; 4; 1; 2; 3; 4] = ([1; 2], [3; 4; 1; 2; 3; 4])
span ((>) 9) [1; 2; 3] = ([1; 2; 3], [])
span ((>) 0) [1; 2; 3] = ([], [1; 2; 3])
*)

let rec span (p: 'a -> bool) lst =
    match lst with
    | [] -> ([], [])
    | x :: xs ->
        if p x then
            let (ys, zs) = span p xs
            (x :: ys, zs)
        else
            ([], lst)


(*
groupBy: Haskell の groupBy と同じ
http://hackage.haskell.org/package/base-4.14.0.0/docs/Data-List.html#v:groupBy
groupBy (=) ("Mississippi" |> List.ofSeq) =
  [['M']; ['i']; ['s'; 's']; ['i']; ['s'; 's']; ['i']; ['p'; 'p']; ['i']]
*)

let rec groupBy (p: 'a -> 'a -> bool) lst: list<list<'a>> =
    match lst with
    | [] -> []
    | x :: xs ->
        let (ys, zs) = span (p x) xs
        (x :: ys) :: groupBy p zs

(*
group: Haskell の group と同じ
http://hackage.haskell.org/package/base-4.14.0.0/docs/Data-List.html#v:group
group ("Mississippi" |> List.ofSeq)
[['M']; ['i']; ['s'; 's']; ['i']; ['s'; 's']; ['i']; ['p'; 'p']; ['i']]
*)

let group xs = groupBy (=) xs
group ("Mississippi" |> List.ofSeq)

(*
zipWith: FSharpPlus では ZipList?
zipWith (+) [1;2;3] [2;4;6]
[3; 6; 9]
*)

// map2 を使えばいい
let zipWith f xs ys =
    List.zip xs ys |> List.map (fun (x, y) -> f x y)
