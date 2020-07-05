#!/usr/bin/env stack
-- stack script --resolver lts-16.0
-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_2_A&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=1460503#1
import Control.Monad (mapM_)
import Data.List (intercalate)

main =
  getLine >>
    getLine >>=
      mapM_ putStrLn . solve . map (read :: String -> Int) . words

solve :: [Int] -> [String]
solve xs = [intercalate " " (map show ys), show c]
  where
    (c, ys) = bsort (0, xs)

bsort :: (Ord a) => (Int, [a]) -> (Int, [a])
bsort (c, []) = (c, [])
bsort (c, xs) = (nnc, y : zs)
  where
    (nnc, zs) = bsort (nc, ys)
    (nc, (y:ys)) = bsort' (c, xs)

bsort' :: (Ord a) => (Int,[a]) -> (Int,[a])
bsort' (c, [x]) = (c, [x])
bsort' (c, (x:xs))
  | x <= y = (nc, x:y:ys)
  | otherwise = (nc+1, y:x:ys)
  where
    (nc, (y:ys)) = bsort' (c, xs)
