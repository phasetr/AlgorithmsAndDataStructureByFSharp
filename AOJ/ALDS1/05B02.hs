-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/all/ALDS1_5_B
{-# LANGUAGE BangPatterns #-}
import Data.List (unfoldr)
import qualified Data.ByteString.Char8 as BS

divide :: Int -> [Int] -> (Int, [Int])
divide !c []   = (c, [])
divide !c [!x] = (c, [x])
divide !c !xs  = conq (divide c left) (divide c right)
  where (left, right) = splitAt (length xs `div` 2) xs

conq :: (Int, [Int]) -> (Int, [Int]) -> (Int, [Int])
conq (!c1, []) (!c2, !ys) = (c1 + c2 + length ys, ys)
conq (!c1, !xs) (!c2, []) = (c1 + c2 + length xs, xs)
conq (!c1, !xs) (!c2, !ys)
  | y < x     = f y $ conq (c1, xs) (c2 + 1, tail ys)
  | otherwise = f x $ conq (c1 + 1, tail xs) (c2, ys)
  where
    f !a (!b, !c) = (b, a:c)
    x = head xs
    y = head ys

main :: IO ()
main = do
  getLine
  xs <- fmap (unfoldr (BS.readInt . BS.dropWhile (== ' '))) BS.getLine
  let (a, bs) = divide 0 xs
  putStrLn $ unwords (map show bs)
  print a

test :: IO ()
test = print $ divide 0 [8,5,9,2,6,3,7,1,10,4] == (34,[1,2,3,4,5,6,7,8,9,10])
