#!/usr/bin/env stack
-- stack script --resolver lts-16.0
-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_3_D&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=1709762#1
main = getLine >>=
  putStrLn . show
  . (\[a, b, c] -> length [x | x <- [a..b], c `mod` x == 0])
  . map (read :: String -> Int) . words

{-
main = getLine >>=
  putStrLn
  . (\[a, b, c] -> show . length $ filter ((==) 0 . mod c) [a..b])
  . map read . words
-}
