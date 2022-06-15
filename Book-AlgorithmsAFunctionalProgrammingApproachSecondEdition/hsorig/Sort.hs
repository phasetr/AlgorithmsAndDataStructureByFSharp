module Sort where
import Data.Array ( Ix, Array, elems, accumArray )
import Graph ( adjacent, nodes, Graph )
import PQueue ( frontPQ, dePQ, enPQ, pqEmpty, emptyPQ, PQueue )
import BinTree ( buildTree, inorder )

-- | P.118 6.3 Basic sorting algorithms
-- P.118 6.3.1 Selection sort
ssort :: Ord a => [a] -> [a]
ssort [] = []
ssort (x:xs) = split xs x [] where
  -- | P.118, Support function for ssort
  split :: (Ord a) => [a] -> a -> [a] -> [a]
  split [] m r = m : ssort r
  split (x:xs) m r = if x < m then split xs x (m:r) else split xs m (x:r)

-- | P.119, 6.3.2 Insertion Sort
isort :: (Foldable t1, Ord t2) => t1 t2 -> [t2]
isort = foldr insert []

-- | P.119, Support function for ssort
insert :: Ord t => t -> [t] -> [t]
insert key [] = [key]
insert key l@(x:xs)
  | key <=x   = key : l
  | otherwise = x : insert key xs

-- | P.119, 6.3.3 Quicksort
-- note this is different from the book version
-- it is the correct and more efficient version
qsort :: Ord a => [a] -> [a]
qsort l = qs l [] where
  qs []  s          = s
  qs [x] s          = x:s
  qs (pivot:rest) s = split pivot rest [] [] s
  split pivot [] lower upper s = qs lower (pivot : qs upper s)
  split pivot (x:xs) lower upper s =
    if x < pivot
    then split pivot xs (x:lower) upper s
    else split pivot xs lower (x:upper) s

-- | P.120, support function
merge :: (Ord a) => [a] -> [a] -> [a]
merge [] b = b
merge a [] = a
merge a@(x:xs) b@(y:ys)
  | x<=y      = x : merge xs b
  | otherwise = y : merge a ys

-- | P.122, support function
mergepairs :: (Ord a) => [[a]] -> [[a]]
mergepairs []           = []
mergepairs x@[l]        = x
mergepairs (l1:l2:rest) = merge l1 l2 : mergepairs rest

-- | P.122, 6.3.4 Mergesort
msort :: (Ord a) => [a] -> [a]
msort l = ms (split l) where
  ms [r] = r
  ms l   = ms (mergepairs l)
  -- | P.122, support function
  split :: (Ord a) => [a] -> [[a]]
  split []     = []
  split (x:xs) = [x] : split xs

-- | P.123
mkPQ  :: (Ord a) => [a] -> PQueue a
mkPQ = foldr enPQ emptyPQ

-- | P.122 Tree based sorting
-- P.123, 6.4.1 Heap Sort
hsort :: (Ord a) => [a] -> [a]
hsort xs = hsort' (mkPQ xs) where
  hsort' pq
    | pqEmpty pq = []
    | otherwise  = frontPQ pq : hsort' (dePQ pq)

-- | P.123, 6.4.2 Tree sort
tsort :: (Ord a, Show a) => [a] -> [a]
tsort = inorder . buildTree

-- | P.130, for Radix Sort
type Key val     = [val]
type Bucket  val = [Key val]
type Buckets val = Array val (Bucket val)

-- | Improved
concatA :: Ix a => Buckets a -> [Key a]
concatA = foldr rev [] . elems where
  rev []     res = res
  rev (x:xs) res = rev xs (x:res)

-- | more efficient but more obscure version of concatA' that
-- combines the effect of concat and (map reverse)
rsort :: Ix a => Int -> (a, a) -> [Key a] -> [Key a]
rsort 0 bnds l = l
rsort p bnds l = rsort (p-1) bnds (concatA (split (p-1) bnds l)) where
  -- | P.132, Improved version
  split :: (Ix a) => Int -> (a,a) -> [Key a] -> Buckets a
  split k bnds l = accumArray f [] bnds [(x!!k,x) | x <- l]
    where f l key = key : l

-- | P.145
inDegree :: (Ix a, Num w, Eq w) => Graph a w -> a -> Int
inDegree g n  = length [t | v<-nodes g, t<-adjacent g v, n==t]
-- | P.144, 7.4 Topological sort, P.145
topologicalSort :: (Ix n, Num w, Eq w) => Graph n w -> [n]
topologicalSort g = tsort [n | n<-nodes g , inDegree g n == 0] [] where
  tsort [] r      = r
  tsort (c:cs) vis
    | c `elem` vis = tsort cs vis
    | otherwise  = tsort cs (c : tsort (adjacent g c) vis)
