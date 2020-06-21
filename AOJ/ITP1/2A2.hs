#!/usr/bin/env stack
-- stack script --resolver lts-16.0
-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_2_A&lang=ja
main :: IO ()
main = getLine >>= putStrLn . sol . map read . words

sol :: [Int] -> String
sol [a, b]
  | a > b  = "a > b"
  | a < b  = "a < b"
  | a == b = "a == b"
