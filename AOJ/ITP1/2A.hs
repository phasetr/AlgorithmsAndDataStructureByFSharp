#!/usr/bin/env stack
-- stack script --resolver lts-16.0
-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_2_A&lang=ja
main :: IO ()
main = do
  [a, b] <- map (read :: String -> Int) . words <$> getLine
  let s | a < b  = "a < b"
        | a > b  = "a > b"
        | a == b = "a == b"
  putStrLn s
