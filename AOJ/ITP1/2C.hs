#!/usr/bin/env stack
-- stack script --resolver lts-16.0
-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_2_C&lang=ja
import Data.List
main :: IO ()
main =
  getLine >>= putStrLn . unwords . map show . sort . map (read :: String -> Int) . words
