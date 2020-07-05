#!/usr/bin/env stack
-- stack script --resolver lts-16.0
-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_1_D&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=3721209#1
import Control.Monad (replicateM)

f :: (Int, Int) -> Int -> (Int, Int)
f (m, r) x =
  (min m x, max r (x-m))

main :: IO ()
main =
  readLn >>=
    flip replicateM readLn >>=
      \(x:xs) -> print $ snd $ foldl f (x, -1000000007) xs
