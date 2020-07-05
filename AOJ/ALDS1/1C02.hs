#!/usr/bin/env stack
-- stack script --resolver lts-16.0
-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_1_C&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=2407232#1
main :: IO()
main =
  getContents >>=
    print . length . filter (==True)
    . map solve . map read . lines

solve :: Int -> Bool
solve x =
  let y = (floor.sqrt.realToFrac) x
  in
    all ((/= 0).(mod x)) [2..y]
