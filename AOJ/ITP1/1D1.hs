#!/usr/bin/env stack
-- stack script --resolver lts-16.0
-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_1_D&lang=ja
main :: IO ()
main = do
   s <- readLn :: IO Int
   putStrLn $ foldl1 (\x y -> x ++ ":" ++ y) $ map show [s `div` 3600, s `div` 60 `mod` 60, s `mod` 60]
