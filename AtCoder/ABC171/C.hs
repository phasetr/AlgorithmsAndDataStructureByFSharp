#!/usr/bin/env stack
-- stack script --resolver lts-16.0
-- https://atcoder.jp/contests/abc171/tasks/abc171_c
-- https://atcoder.jp/contests/abc171/submissions/14569358
main :: IO ()
main = readLn >>= putStrLn . solve

solve :: Integer -> String
solve x
  | x <= 26 = [['a'..] !! fromIntegral (x - 1)]
  | (q, r) <- divMod (x - 1) 26 = solve q ++ [['a'..] !! fromIntegral r]
