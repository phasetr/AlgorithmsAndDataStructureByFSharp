#r "nuget: FsUnit"
open FsUnit

module InsertStepCheck =
    // See also ../../AOJ/ALDS1/01A01.hs
    let insertion i xs =
        let v = List.item i xs
        let p = List.take i xs
        let smallerThanV = p |> List.filter (fun x -> x<=v)
        let largerThanV = p |> List.filter (fun x -> v<x)
        let iThAndAfter = List.skip (i+1) xs
        smallerThanV @ [v] @ largerThanV @ iThAndAfter
    let f l i = insertion i (List.head l) :: l
    let step n xs = List.fold f [xs] [1..n-1]

    step 6 [5;2;4;6;1;3]
    |> List.rev
    |> should equal [[5;2;4;6;1;3]
                     ;[2;5;4;6;1;3]
                     ;[2;4;5;6;1;3]
                     ;[2;4;5;6;1;3]
                     ;[1;2;4;5;6;3]
                     ;[1;2;3;4;5;6]]

    step 3 [1;2;3]
    |> List.rev
    |> should equal [[1;2;3];[1;2;3];[1;2;3]]

// http://www.fssnip.net/e9/title/Insertion-Sort-on-List
module Insert1 =
    // An insert function
    let insert x lst =
        let rec insertCont x cont =
            function
            | [] -> cont ([ x ])
            | h :: t as l ->
                if x <= h
                then cont (x :: l)
                else insertCont x (fun accLst -> cont (h :: accLst)) t

        insertCont x id lst

    // Sorting via insertion
    let insertionSort l =
        let rec insertionSortAcc acc =
            function
            | [] -> acc
            | h :: t -> insertionSortAcc (insert h acc) t

        insertionSortAcc [] l

    insertionSort [24;33;-5;-16;0] |> should equal [-16;-5;0;24;33]

// https://stackoverflow.com/questions/9518850/insertion-sort-implementation-with-one-recursive-function-and-foldback-function
module Insert2 =
    let rec insert x =
        function
        | [] -> [ x ]
        | y :: ys -> if x <= y then x :: y :: ys else y :: (insert x ys)

    and insertionSort =
        function
        | [] -> []
        | x :: xs -> insert x (insertionSort xs)
    insertionSort [24;33;-5;-16;0] |> should equal [-16;-5;0;24;33]

module Insert3 =
    let rec insert x =
        function
        | [] -> [ x ]
        | y :: ys -> if x <= y then x :: y :: ys else y :: (insert x ys)

    let rec insertionSort =
        function
        | [] -> []
        | x :: xs -> insert x (insertionSort xs)
    insertionSort [24;33;-5;-16;0] |> should equal [-16;-5;0;24;33]
