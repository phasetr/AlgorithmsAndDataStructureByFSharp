#!/usr/bin/env stack
-- stack script --resolver lts-16.0
-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_3_D&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=2082881#1
main =
  getLine >>=
    putStrLn
    . (\[a, b, c] -> show . length $ filter ((==) 0 . mod c) [a..b])
    . map (read :: String -> Int) . words
