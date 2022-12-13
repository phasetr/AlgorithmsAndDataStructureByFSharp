-- P.187, 8.2 Huffman coding trees
module Sec0802 where
import Lib (Nat,apply,picks,single,unwrap,wrap)
import Sec0301 (SymList,headSL,nilSL,nullSL,singleSL,snocSL,tailSL)
import Sec0801 (Tree(..),Forest,fringe)

-- P.188
depths :: Tree a -> [Nat]
depths = from 0
  where
    from :: Nat -> Tree a -> [Nat]
    from n (Leaf x) = [n]
    from n (Node u v) = from (n+1) u ++ from (n+1) v

-- P.188
type Weight = Nat
type Elem = (Char, Weight)
type Cost = Nat

-- P.189
cost :: Tree Elem -> Cost
cost t = sum [w*d | ((_,w), d) <- zip (fringe t) (depths t)]

-- P.189
cost1 :: Tree Elem -> Cost
cost1 (Leaf e) = 0
cost1 (Node u v) = cost u + cost v + weight u + weight v
-- P.189
weight :: Tree Elem -> Nat
weight (Leaf (c,w)) = w
weight (Node u v) = weight u + weight v

-- P.189, P.194
-- huffman <- MinWith cost . mktrees
huffman :: [Elem] -> Tree Elem
huffman es = unwrap (until single gstep (map Leaf es))
  where
    gstep (t1:t2:ts) = insert (Node t1 t2) ts
    gstep _ = error "gstep: needs more elements in the argument"

-- P.190
mktrees :: [Elem] -> [Tree Elem]
mktrees = map unwrap . mkforests . map Leaf
  where
    mkforests :: Forest Elem -> [Forest Elem]
    mkforests = until (all single) (concatMap combine) . wrap

-- P.190
combine :: Forest Elem -> [Forest Elem]
combine ts = [insert (Node t1 t2) us | ((t1,t2),us) <- pairs ts]
-- P.190
pairs :: [a] -> [((a,a), [a])]
pairs xs = [((x,y),zs) | (x,ys) <- picks xs, (y,zs) <- picks ys]

-- P.203, Answer8.11
insert :: Tree Elem -> Forest Elem -> Forest Elem
insert t1 [] = [t1]
insert t1 (t2:ts) =
  if weight t1 <= weight t2 then t1:t2:ts else t2:insert t1 ts

-- P.191
mkforests1 :: Forest Elem -> [Forest Elem]
mkforests1 ts = apply (length ts - 1) (concatMap combine) [ts]

{-
P.191 Another generic greedy algorithm
candidates :: State -> [Candidate]
candidates ts = map unwrap (mkforests ts)
extract (until final gstep sx) <- MinWith cost (candidates sx)
gstep :: State -> State
final :: State -> Bool
extract :: State -> Candidate
-}

-- P.193, Huffman coding continued
-- P.194, SQ is Stack-Queues
type SQ a = (Stack a, Queue a)
type Stack a = [a]
type Queue a = SymList a

-- P.194
huffman2 :: [Elem] -> Tree Elem
huffman2 = extractSQ . until singleSQ gstep . makeSQ . map leaf

-- P.195
type Pair = (Tree Elem, Weight)

-- P.195
leaf :: Elem -> Pair
leaf (c,w) = (Leaf (c,w), w)
-- P.195
node :: Pair -> Pair -> Pair
node (t1,w1) (t2,w2) = (Node t1 t2, w1+w2)
-- P.195
makeSQ :: [Pair] -> SQ Pair
makeSQ xs = (xs, nilSL)
-- P.195
singleSQ :: SQ a -> Bool
singleSQ (xs,ys) = null xs && singleSL ys
-- P.195
extractSQ :: SQ Pair -> Tree Elem
extractSQ (xs,ys) = fst (headSL ys)

-- P.195
gstep :: SQ Pair -> SQ Pair
gstep ps = add (node p1 p2) rs
  where
    (p1,qs) = extractMin ps
    (p2,rs) = extractMin qs
-- P.195
add :: Pair -> SQ Pair -> SQ Pair
add y (xs,ys) = (xs, snocSL y ys)
-- P.196
extractMin :: SQ Pair -> (Pair, SQ Pair)
extractMin (xs,ys)
  | nullSL ys = (head xs, (tail xs, ys))
  | null xs = (headSL ys, (xs, tailSL ys))
  | snd x <= snd y = (x, (tail xs, ys))
  | otherwise = (y, (xs, tailSL ys))
  where x = head xs; y = headSL ys

-- P.201, Exercise8.11, P.203 Answer8.11
-- bestjoin: omitted
insert2 :: Tree Elem -> Forest Elem -> Forest Elem
insert2 t1 [] = [t1]
insert2 t1 (t2 :ts) = if weight t1 <= weight t2 then t1:t2:ts else t2 : insert t1 ts
