#!/usr/bin/env stack
-- stack script --resolver lts-16.0
-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_1_C&lang=ja
main :: IO ()
main = do
  [a, b] <- map read . words <$> getLine
  print . unwords . map show $ [a*b, 2*(a+b)]
