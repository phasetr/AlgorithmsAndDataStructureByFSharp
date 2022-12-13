module Sec1301 where
import Data.Array (Ix(range),Array,(!),array)
import Data.List (scanr1)
import Lib (Nat,apply)
-- P.313 13.1 Two numeric examples
-- P.313
fib1 :: Nat -> Integer
fib1 n = if n <= 1 then fromIntegral n else fib1 (n-1) + fib1 (n-2)

-- P.314
fib2 :: Nat -> Integer
fib2 n = a!n where
  a = tabulate f (0,n)
  f i = if i<=1 then fromIntegral i else a!(i-1) + a!(i-2)

-- P.314
tabulate :: Ix i => (i -> e) -> (i,i) -> Array i e
tabulate f bounds = array bounds [(x, f x) | x <- range bounds]

-- P.314
fib3 :: Nat -> Integer
fib3 n = fst (apply n step (0,1)) where
  step (a,b) = (b,a+b)
  apply n step (0,1) = (fib3 n, fib3 (n+1))
  apply _ _ _ = error "undefined"

-- P.314
binom1 :: (Nat,Nat) -> Integer
binom1 (n,r) = fact n `div` (fact r * fact (n-r))
  where fact n = product [1..fromIntegral n]

-- P.315
binom2 :: (Nat,Nat) -> Integer
binom2 (n,r) = if r == 0 || r == n then 1
  else binom2 (n-1,r) + binom2 (n-1, r-1)

-- P.315
binom3 :: (Nat,Nat) -> Integer
binom3 (n,r) = a!(n,r) where
  a = tabulate f ((0,0),(n,r))
  f (i,j) = if j==0 || i==j then 1 else a!(i-1,j)+a!(i-1,j-1)

-- P.316
binom4 :: Num a => (Nat, Nat) -> a
binom4 (n,r) = head (apply (n-r) (scanr1 (+)) (replicate (r+1) 1))
