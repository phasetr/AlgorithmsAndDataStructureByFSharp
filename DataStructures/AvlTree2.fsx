// Rabhi-Lapalme P.107
module AvlTree =
    type AvlTree<'a when 'a: comparison> =
        | EmptyAvl
        | NodeAvl of 'a * 'a AvlTree * 'a AvlTree

    let emptyAvl = EmptyAvl
