#!/usr/bin/env stack
-- stack script --resolver lts-16.0
-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_3_B&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=2399956#1
main =
  getContents >>=
    mapM putStrLn
    . map (\(i, l) -> "Case " ++ (show i) ++ ": " ++ l)
    . takeWhile (\(i, l) -> l /= "0")
    . zip [1..] . lines
