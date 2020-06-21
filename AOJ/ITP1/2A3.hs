#!/usr/bin/env stack
-- stack script --resolver lts-16.0
-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_2_A&lang=ja
main :: IO ()
main = getLine >>= putStrLn . judge . map read . words

judge :: [Int] -> String
judge [a, b] =
  case a `compare` b of
    LT -> "a < b"
    EQ -> "a == b"
    GT -> "a > b"
