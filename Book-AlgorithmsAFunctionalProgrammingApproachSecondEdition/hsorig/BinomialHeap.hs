module BinomialHeap(Heap(..),Tree(..),emptyHeap,heapEmpty,findHeap,insHeap,delHeap) where

emptyHeap :: (Ord a) => Heap a
heapEmpty :: (Ord a) => Heap a -> Bool
findHeap  :: (Ord a) => Int -> Heap a -> a
insHeap   :: (Ord a) => a -> Heap a -> Heap a
delHeap   :: (Ord a) => Int -> Heap a -> Heap a

-- IMPLEMENTATION with Binomial Heap
-- adapted from C. Okasaki Purely Functional Data Structures p 198
data Tree a = Node Int a [Tree a] deriving (Show,Eq)
newtype Heap a = BH [Tree a] deriving (Show,Eq)

rank :: Tree a -> Int
rank (Node r _ _) = r
root :: Tree a -> a
root (Node _ x _) = x

link :: (Eq a,Ord a) => Tree a -> Tree a -> Tree a
link t1@(Node r x1 c1) t2@(Node _ x2 c2)
  | x1 <= x2  = Node (r+1) x1 (t2:c1)
  | otherwise = Node (r+1) x2 (t1:c2)

insTree :: (Eq a,Ord a) => Tree a -> [Tree a] -> [Tree a]
insTree t []               = [t]
insTree t ts@(t':ts')
  | rank t < rank t' = t:ts
  | otherwise        = insTree (link t t') ts'

mrg :: (Eq a,Ord a) => [Tree a] -> [Tree a] -> [Tree a]
mrg ts1 []              = ts1
mrg [] ts2              = ts2
mrg ts1@(t1:ts1') ts2@(t2:ts2')
  | rank t1 < rank t2 = t1:mrg ts1' ts2
  | rank t2 < rank t1 = t1:mrg ts1  ts2'
  | otherwise         = insTree (link t1 t2) (mrg ts1' ts2')

removeMinTree :: (Eq a,Ord a) => [Tree a] -> (Tree a, [Tree a])
removeMinTree []                 = error "empty Heap"
removeMinTree [t]                = (t,[])
removeMinTree (t:ts)
  | root t < root t' = (t,ts)
  | otherwise        = (t',t:ts')
  where (t',ts') = removeMinTree ts

emptyHeap = BH []
heapEmpty (BH ts) = null ts

findHeap 1 (BH ts) = root (fst (removeMinTree ts))
findHeap _ _       = error "findHeap: not looking for first"

insHeap x (BH ts) = BH (insTree (Node 0 x []) ts)

delHeap 1 (BH ts) = BH (mrg (reverse ts1) ts2)
  where (Node _ _ ts1, ts2) = removeMinTree ts
delHeap _ _            = error "delHeap: not looking for first"