-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_D/review/4209664/niruneru/Haskell
{-# LANGUAGE BangPatterns #-}
import Data.List (splitAt, unfoldr)
import qualified Data.ByteString.Char8 as BS

divide :: Int -> Int -> [Int] -> (Int, Int, [Int])
divide !size !count !xs
  | length xs < 2 = (size, count, xs)
  | otherwise     = conq (divide size count xl) (divide size count xr)
  where (xl, xr) = splitAt (length xs `div` 2) xs

conq :: (Int, Int, [Int]) -> (Int, Int, [Int]) -> (Int, Int, [Int])
conq (!s1, !c1, []) (!s2, !c2, ys) = (s1 + s2, c1 + c2, ys)
conq (!s1, !c1, xs) (!s2, !c2, []) = (s1 + s2, c1 + c2, xs)
conq (!s1, !c1, x:xs) (!s2, !c2, y:ys)
  | y < x          = f x $ conq (s1 - 1, c1 + s2, xs) (s2, c2, y:ys)
  | otherwise      = f y $ conq (s1, c1, x:xs) (s2 - 1, c2, ys)
  where
    f a (!b, !c, d) = (b + 1, c, a:d)

main :: IO ()
main = do
  getLine
  xs <- fmap (unfoldr (BS.readInt . BS.dropWhile (' ' ==))) BS.getLine
  let (_, a, _) = divide 1 0 xs
  print a

test = do
  print $ divide 1 0 [3,5,2,1,4]
  print $ divide 1 0 [3,1,2]
