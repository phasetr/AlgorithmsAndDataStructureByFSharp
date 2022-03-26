#!/usr/bin/env stack
-- stack script --resolver lts-16.0
-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_1_B&lang=ja
main :: IO ()
main = readLn >>= print . solve1
solve1 x = x^3

test = solve1 2 == 8
  && solve1 3 == 27

{-
main = readLn >>= print . (^3)
-}
