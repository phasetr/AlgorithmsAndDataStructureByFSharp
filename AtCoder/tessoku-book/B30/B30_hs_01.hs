-- https://atcoder.jp/contests/tessoku-book/submissions/37930865
{-# LANGUAGE BangPatterns #-}

main :: IO ()
main = get >>= print . sol

get :: IO [Int]
get = map read . words <$> getLine

sol :: [Int] -> Int
sol (h:w:_) = comb (h+w-2) (h-1)
sol _ = error "not come here"

inv :: Int -> Int
inv 1 = 1
inv a = pwr a (p-2)

pwr :: Integral t => Int -> t -> Int
pwr !a !n
  | n == 0    = 1
  | odd n     = a .*. r
  | otherwise = r
  where
    q = pwr a (n `div` 2)
    r = q .*. q

fac :: Int -> Int
fac 0 = 1
fac n = n .*. fac (n-1)

perm :: (Eq t, Num t) => Int -> t -> Int
perm n 0 = 1
perm n m = n .*. perm (n-1) (m-1)

comb :: Int -> Int -> Int
comb n m = perm n m' .*. inv (fac m') where
  m' = min m (n-m)

p = 10^9+7 :: Int

(.*.) :: Int -> Int -> Int
(.*.) = ((`mod` p) .) . (*)
infixl 7 .*.

(.+.) :: Int -> Int -> Int
(.+.) = ((`mod` p) .) . (+)
infixl 6 .+.
