#!/usr/bin/env stack
-- stack script --resolver lts-16.0
-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_4_A&lang=ja
-- 最後が Double なので計算結果をリストに落とせないことに注意する
-- import Text.Printf
-- main = getLine >>=
--        (\[a,b] -> printf "%d %d %.8f\n" (a `div` b) (a `mod` b) ((fromIntegral a / fromIntegral b) :: Double))
--        . map read . words

import Text.Printf
main = interact $ f . map read . words
f [a,b] = printf "%d %d %.8f\n"
          ((a `div` b)::Int)
          (a `mod` b)
          ((fromIntegral a / fromIntegral b) :: Double)
