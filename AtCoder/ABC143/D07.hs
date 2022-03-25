{-
https://atcoder.jp/contests/abc143/submissions/24846730
-}
module Main where

import Debug.Trace
import Data.List

main :: IO ()
main = do
  getLine
  ls <- map read . words <$> getLine
  print $ solve ls

solve :: [Int] -> Int
solve ls = step ls'
  where
    ls' = zip [1..] . sort $ ls

step :: [(Int, Int)] -> Int
step [] = 0
step [_] = 0
step ((ai, a):b:ls) = search a (b:ls) ls + step (b:ls)

search :: Int -> [(Int, Int)]  -> [(Int, Int)] -> Int
search _ [] _ = 0
search _ _ [] = 0
search a bl@((bi, b):bs) cl@((ci, c):cs)
    | c < a + b = ci - bi + search a bl cs
    | bi + 1  == ci = search a bl cs
    | otherwise = search a bs cl
