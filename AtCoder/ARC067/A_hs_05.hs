-- https://atcoder.jp/contests/abc052/submissions/11068320
import Data.List ( group )
main :: IO ()
main = interact $ show . sol . read

sol :: Integral a => a -> Int
sol n = d $ product [1..n] where
  md = 10^9+7
  prod a b = a*b `mod` md
  d 1 = 1
  d n = foldr1 prod . fmap (succ . length) . group $ primeFactors n

primeFactors :: Integral a => a -> [a]
primeFactors 1 = []
primeFactors n = factor n primes where
  primes = 2 : filter ((==1) . length . primeFactors) [3,5..]
  factor n (p:ps)
    | p*p > n        = [n]
    | n `mod` p == 0 = p:factor (n `div` p) (p:ps)
    | otherwise      = factor n ps
  factor _ _ = error "not come here"
