module Sec0404 where
import Sec040302 (Tree(Null,Node),balance,gbalance,Set)
-- P.81 4.4 Dynamic sets

-- P.81
member :: Ord a => a -> Set a -> Bool
member x Null = False
member x (Node _ l y r)
  | x<y = member x l
  | x == y = True
  | x>y = member x r
  | otherwise = error "undefined"

-- P.81
delete :: Ord a => a -> Set a -> Set a
delete x Null = Null
delete x (Node _ l y r)
  | x<y = balance (delete x l) y r
  | x == y = combine l r
  | x>y = balance l y (delete x r)
  | otherwise = error "undefined"

-- P.82
deleteMin :: Ord a => Set a -> (a,Set a)
deleteMin (Node _ Null x r) = (x,r)
deleteMin (Node _ l x r) = (y,balance t x r) where (y,t) = deleteMin l
deleteMin _ = error "undefined"
combine :: Ord a => Set a -> Set a -> Set a
combine l Null = l
combine Null r = r
combine l r = balance l x t where (x,t) = deleteMin r

-- P.82
split :: Ord a => a -> Set a -> (Set a,Set a)
split x t = sew (pieces x t)

-- P.82
data Piece a = LP (Set a) a | RP a (Set a)

-- P.83
pieces :: Ord a => a -> Set a -> [Piece a]
pieces x t = addPiece t [ ] where
  addPiece Null ps = ps
  addPiece (Node _ l y r) ps | x<y  = addPiece l (RP y r :ps)
                             | x>=y = addPiece r (LP l y:ps)
  addPiece _ _ = error "undefined"

-- P.83
sew :: [Piece a] -> (Set a,Set a)
sew = foldl step (Null,Null) where
  step (t1,t2) (LP t x) = (gbalance t x t1,t2)
  step (t1,t2) (RP x t) = (t1,gbalance t2 x t)
