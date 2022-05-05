-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/all/ALDS1_5_D
{-# LANGUAGE BangPatterns #-}
import Data.List (unfoldr)
import qualified Data.ByteString.Char8 as BS

main :: IO ()
main = getLine >> BS.getLine >>=
  print . solve . unfoldr (BS.readInt . BS.dropWhile (' ' ==))

solve :: [Int] -> Int
solve = (\(a,_,_) -> a) . help 0 1

help :: Int -> Int -> [Int] -> (Int,Int,[Int])
help !cnt !size !xs
  | n < 2     = (cnt,size,xs)
  | otherwise = count (help cnt size ls) (help cnt size rs)
  where
    n = length xs
    (ls,rs) = splitAt (length xs `div` 2) xs

count :: (Int,Int,[Int]) -> (Int,Int,[Int]) -> (Int,Int,[Int])
count (!c1,!s1,[]) (!c2,!s2,ys) = (c1+c2,s1+s2,ys)
count (!c1,!s1,xs) (!c2,!s2,[]) = (c1+c2,s1+s2,xs)
count (!c1,!s1,x:xs) (!c2,!s2,y:ys)
  | y < x     = f x $ count (c1+s2,s1-1,xs) (c2,s2,y:ys)
  | otherwise = f y $ count (c1,s1,x:xs)    (c2,s2-1,ys)
  where
    f a (!c,!s,l) = (c,s+1,a:l)

test :: IO ()
test = do
  print $ help 0 1 [3,5,2,1,4]
  print $ help 0 1 [3,1,2]
  print $ solve [3,5,2,1,4] == 6
  print $ solve [3,1,2] == 2
