module Tree =
    // Haskell
    // data Tree a = Node a [Tree a] deriving Show
    type 'a Tree =
        | Node of 'a
        | Tree of 'a list

    // TODO P.39 depth

Tree.Node 1 |> printfn "%A"
Tree.Tree [1; 2; 3] |> printfn "%A"

module BinTree =
    // Haskell
    // data BinTree a = Empty | NodeBT a (BinTree a) (BinTree a) deriving Show
    type 'a BinTree =
        | Empty
        | NodeBT of 'a * 'a BinTree * 'a BinTree

BinTree.Empty |> printfn "%A"
BinTree.NodeBT (1,
    BinTree.NodeBT (1, BinTree.NodeBT (1, BinTree.Empty, BinTree.Empty), BinTree.Empty),
    BinTree.Empty)
|> printfn "%A"

module BinTree2 =
    // Haskell
    // data BinTree ' a = Leaf a I NodeBT ' a (BinTree ' a) (BinTree ' a) deriving Show
    type 'a BinTree =
        | Leaf of 'a
        | NodeBT of 'a * 'a BinTree * 'a BinTree

BinTree2.Leaf 1 |> printfn "%A"
BinTree2.NodeBT (1, BinTree2.Leaf 2, BinTree2.Leaf 3) |> printfn "%A"
