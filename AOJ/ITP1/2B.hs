#!/usr/bin/env stack
-- stack script --resolver lts-16.0
-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_2_B&lang=ja
main :: IO ()
main = getLine >>=
  putStrLn
  . (\[a,b,c] -> if a < b && b < c then "Yes" else "No")
  . map read . words
