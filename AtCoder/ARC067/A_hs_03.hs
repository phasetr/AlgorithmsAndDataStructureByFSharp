-- https://atcoder.jp/contests/abc052/submissions/2830417
import Control.Monad ()
import Data.List ()
import qualified Data.IntMap as M

pr :: [Int]
pr = 2:3:1 # pr
(#) :: Integral a => a -> [a] -> [a]
m # (a:b:x) = [n | n <- [a^2..b^2-2], odd n, gcd n m<2] ++ (m*b) # (b:x)
m # _ = error "not come here"

fac :: Num a => [Int] -> M.IntMap a -> Int -> M.IntMap a
fac _ m 1 = m
fac pa@(p:pr) m n
  | n`mod`p == 0 = fac pa (M.insertWith(+)p 1 m) (n`div`p)
  | otherwise = fac pr m n
fac _ _ _ = error "not come here"

main :: IO ()
main = do
  n <- readLn
  print.foldl (\a n->(a*(n+1))`mod`1000000007) 1.M.elems $ foldl (fac pr) M.empty [2..n]
