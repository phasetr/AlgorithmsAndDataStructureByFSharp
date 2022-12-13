module Ex13 where
import Data.Array ((//),(!),listArray)
import Lib (Nat,apply,minWith)
import Sec1301 (tabulate)
import Sec1302 (add,better,weight)
import Sec1303 (Op(..),ecost)
import Sec1305 (Passengers,Leg,atmost,legcost,ptails)
-- P.327 Exercise13.2, P.330 Answer13.2
fibs :: [Integer]
fibs = 0:1:zipWith (+) fibs (tail fibs)

-- P.327 Exercise13.3, P.330 Answer13.3
fib :: Integer -> Integer
fib = fst . foldr step (0,1) . binary where
  binary n = if n == 0 then [] else r :binary q
    where (q,r) = n `divMod` 2
  step k (a,b) = if k == 0 then (c,d) else (d,c+d) where
    c = a * (2*b-a)
    d = a*a+b*b

-- P.327 Exercise13.4, P.331 Answer13.4
{-
fob :: Nat -> Integer
fob n = if n <= 2 then fromIntegral n else fob (n-1)+fob (n-3)
-}
fob :: Num c => Nat -> c
fob n = fst3 (apply n step (0,1,2)) where
  step (a,b,c) = (b,c,a+c)
  fst3 (a,b,c) = a

-- P.327 Exercise13.5, P.331 Answer13.5
{-
stirling :: (Nat,Nat) -> Integer
stirling (n,r)
  | r == n = 1
  | r == 0 = 0
  | otherwise = fromIntegral r * stirling (n-1,r)+stirling (n-1,r-1)
-}
stirling :: (Nat,Nat) -> Integer
stirling (n,r) = a!(n,r) where
  a = tabulate f ((0,0),(n,r))
  f (i,j)
    | i == j = 1
    | j == 0 = 0
    | otherwise = fromIntegral j * a!(i-1,j)+a!(i-1,j-1)

stirling2 (n,r) = head (apply (n-r) step (replicate (r+1) 1)) where
  step row = scanr1 (+) (zipWith (*) [r',r'-1..0] row)
  r' = fromIntegral r

-- P.328 Exercise13.8, P.331 Answer13.8
swag w items = a!w where
  a = foldr step start items
  start = listArray (0,w) (replicate (w+1) ([ ],0,0))
  step item a = a // [(j,next j item) | j <- [0..w]] where
    next j i = if j<wi then a!j else better (a!j) (add i (a!(j-wi)))
      where wi = weight i

-- P.328 Exercise13.11, P.332 Answer13.11
type Pair = (Nat,[Op])
firstrow :: [Char] -> [Pair]
firstrow = foldr nextentry [(0,[])] where
  nextentry x row = cons (Delete x) (head row):row
cons :: Num a => Op -> (a, [Op]) -> (a, [Op])
cons op (k,es) = (ecost op+k,op:es)
nextrow :: [Char] -> Char -> [Pair] -> [Pair]
nextrow xs y row = foldr step [cons (Insert y) (last row)] xes where
  xes = zip3 xs row (tail row)
  step (x,es1,es2) row = if x == y then cons (Copy x) es2:row else
    minWith fst [ cons (Insert y) es1
                , cons (Replace x y) es2
                , cons (Delete x) (head row)]:row
mce xs ys = extract (foldr (nextrow xs) (firstrow xs) ys)
  where extract = snd . head

-- P.330 Exercise13.15, P.333 Answer13.15
-- split n ps = [cut 0 ps,cut 1 ps,...,cut n ps]
schedule :: Nat -> Nat -> Passengers -> [Leg]
schedule n k ps = extract (apply k step start) where
  extract = snd . head
  start = zipWith entry pss [0..n-1]++[(0,[ ])]
    where entry ps x = (legcost ps (x,n),[(x,n)])
  pss = split n ps
  step t = zipWith3 entry pss [0..n-1] (ptails t)++[(0,[ ])]
  entry ps x ts = minWith fst (zipWith cons [x+1..n] ts) where
    cons y (c,ls) = (legcost (takeWhile (atmost y) ps) (x,y)+c,(x,y):ls)

split :: (Ord a1, Num a1, Enum a1) => a1 -> [(a2, a1)] -> [[(a2, a1)]]
split n ps = scanl op ps [1..n]
  where op qs x = dropWhile (atmost x) qs

-- P.330 Exercise13.16, P.333 Answer13.16
-- cf. Section7.3
mktuples :: Integral t => [t] -> t -> [[t]]
mktuples [1] n = [[n]]
mktuples (d :ds) n = concat [map (c:) (mktuples ds (n-c*d)) | c <- [0..n `div` d]]
mktuples _ _ = error "undefined"

mkchange :: Integral b => [b] -> b -> [b]
mkchange [1] n = [n]
mkchange (d :ds) n = minWith count [ c:mkchange ds (n-c*d) | c <- [0..n `div` d]]
  where count = sum -- P.153
mkchange _ _ = error "undefined"
