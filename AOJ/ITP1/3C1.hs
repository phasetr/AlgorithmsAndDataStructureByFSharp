#!/usr/bin/env stack
-- stack script --resolver lts-16.0
-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_3_C&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=2206675#1
import Data.List
main =
  interact $ unlines . map (unwords . map show . sort . map (read::String->Int) . words) . init . lines
