#!/usr/bin/env stack
-- stack script --resolver lts-16.0
-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_3_B&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=1708835#1
main =
  getContents >>=
    mapM_ putStrLn
    . zipWith (\n m -> "Case " ++ show n ++ ": " ++ m) [1..]
    . init . words
