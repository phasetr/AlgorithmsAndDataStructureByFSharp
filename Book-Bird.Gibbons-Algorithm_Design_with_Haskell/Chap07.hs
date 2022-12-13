import Data.List as L

-- Exercise7.1
minWith f = snd . L.minimumBy cmp . map tuple
  where
    tuple x = (f x,x)
    cmp (x,_) (y,_) = compare x y

-- P.152
usds,ukds::[Denom]
usds = [100,50,25,10,5,1]
ukds = [200,100,50,20,10,5,2,1]

-- Exercise7.14
type Nat = Int
type Denom = Int
type Weights = [Int]
type Tuple = [Int]
weight::Weights -> Tuple -> Int
weight ws cs = sum (zipWith (*) ws cs)

mktuples ds n = finish (foldr (concatMap . extend) [([],n)] (reverse ds))
  where
    finish = map fst . filter (\(cs,r) -> r == 0)
    extend :: Denom -> (Tuple, Int) -> [(Tuple, Int)]
    extend d (cs,r) = [(cs++[c], r-c*d) | c <- [0..r `div` d]]

mkchange ds n = fst (foldr gstep ([], n) (reverse ds))
  where
    gstep d (cs,r) = (cs++[c], r-c*d) where c = r `div` d

mkchangew::Weights -> [Denom] -> Nat -> Tuple
mkchangew ws ds = minWith (weight ws) . mktuples ds

ukws = [1200,950,800,500,650,325,712,356]
test = [n | n <- [1..200], mkchange ukds n /= mkchangew ukws ukds n]
mkchange ukds 2 == [0,0,0,0,0,0,1,0]
mkchangew ukws ukds 2 == [0,0,0,0,0,0,0,2]
