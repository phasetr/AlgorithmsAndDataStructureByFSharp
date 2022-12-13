-- P.274 11.3 A short segment with maximum sum
module Sec1103 where
import Data.List (inits,tails)

import Lib (Nat)
import Sec0301 (SymList,headSL,initSL,lastSL,nilSL,tailSL)

{-
-- P.274
mss :: Nat -> [Integer] -> [Integer]
mss b <- MaxWith sum . filter (short b) . segments
-}

-- P.274
short :: Nat -> [a] -> Bool
short b xs = length xs <= b
-- mss 3 [1,?2,3,0,?5,3,?2,3,?1] = [3,?2,3]

-- P.274
segments :: [a] -> [[a]]
segments = concatMap inits . tails

{-
P.275
mss b ← MaxWith sum・map (msp b)・tails
msp b ← MaxWith sum・filter (short b)・inits
msp 4 [-2,4,4,-5,8,-2,3,1] = [-2,4,4]
msp 6 [-2,4,4,-5,8,-2,3,1] = [-2,4,4,-5,8]
-}

{-
P.275
scanr ::(a → b → b) → b → [a] → [b]
scanr op e [ ] = [e]
scanr op e (x:xs) = op x (head ys):ys where ys = scanr op e xs

scanl::(b → a → b) → b → [a] → [b]
scanl op e [ ]
= [e]
scanl op e (x:xs) = e:scanl op (op e x) xs
-}

{-
P.276
inits :: [a] -> [[a]]
inits = foldr step [[]] where step x xss = []:map (x:) xss

filter (short b) (step x xss) =
  if length (last xss) == b
  then []:map (x:) (init xss)
  else []:map (x:) xss
-}
-- P.276
-- msp b ← MaxWith sum・foldr (op b) [[ ]]
op :: Int -> a -> [[a]] -> [[a]]
op b x xss = [ ]:map (x:) (cut b xss)
cut :: Foldable t => Int -> [t a] -> [t a]
cut b xss = if length (last xss) == b then init xss else xss

-- P.277
(≼) :: (Ord a, Num a, Foldable t1, Foldable t2) => t1 a -> t2 a -> Bool
xs ≼ ys = (sum xs >= sum ys) && (length xs <= length ys)

-- P.277
msp b = last . foldr (op b) [[]] where
  op b x xss = []:thin (map (x:) (cut b xss))
  thin = dropWhile (\xs -> sum xs <= 0)

-- P.277
abst :: [[a]] -> [[a]]
abst = scanl (++) []
-- abst [[-2,4],[4],[-5,8],[-2,3]] == [[ ],[-2,4],[-2,4,4],[-2,4,4,-5,8],[-2,4,4,-5,8,-2,3]]
-- last . abst = concat

{-
P.277
abst (opR b x xss) = op b x (abst xss)

P.278
abst . foldr (opR b) [] == foldr (op b) [[]]
-}

cutR :: Int -> [[a]] -> [[a]]
cutR b xss = if length (concat xss) == b then init xss else xss
-- cut b (abst xss) = abst (cutR b xss)

-- P.278
opR :: (Ord a, Num a) => Int -> a -> [[a]] -> [[a]]
opR b x xss = thinR x (cutR b xss)

-- P.279
thinR :: (Ord a, Num a) => a -> [[a]] -> [[a]]
thinR x xss = add [x] xss where
  add xs xss
    | sum xs>0 = xs:xss
    | null xss = []
    | otherwise = add (xs++head xss) (tail xss)

-- P.279
type Partition = (Sum,Length,SymList Segment)
type Segment = (Sum,Length,[Integer] -> [Integer])
type Sum = Integer
type Length = Nat

-- P.279
opP b x xss = thinP x (cutP b xss)
cutP :: Length -> Partition -> Partition
cutP b xss = if lenP xss == b then initP xss else xss
initP :: Partition -> Partition
initP (s,k,xss) = (s-t, k-m, initSL xss) where (t,m,_) = lastSL xss
-- P.280
thinP :: Integer -> Partition -> Partition
thinP x = add (x,1,([x]++))
add :: Segment -> Partition -> Partition
add xs xss
  | sumS xs > 0 = consP xs xss
  | lenP xss == 0 = emptyP
  | otherwise = add (catS xs (headP xss)) (tailP xss)

-- P.280
consP :: Segment -> Partition -> Partition
consP xs (s,k,xss) = (sumS xs+s, lenS xs+k, consSL xs xss)
emptyP :: Partition
emptyP = (0,0,nilSL)
headP :: Partition -> Segment
headP xss = headSL (segsP xss)
tailP :: Partition -> Partition
tailP (s,k,xss) = (s-t, k-m, tailSL xss) where (t,m,_) = headSL xss
catS :: Segment -> Segment -> Segment
catS (s,k,f) (t,m,g) = (s+t, k+m, f . g)
mss b = extract . maxWith sumP . scanr (opP b) emptyP
extract :: Partition -> [Integer]
extract = concatMap (flip segS []) . fromSL . segsP
