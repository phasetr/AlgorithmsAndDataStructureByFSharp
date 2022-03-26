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

{-
main :: IO ()
main = do
  [a, b] <- map (read :: String -> Int) . words <$> getLine
  putStrLn $ if a < b then "a < b" else if a > b then "a > b" else "a == b"

main :: IO ()
main = getLine >>= putStrLn . solve2 . map read . words
solve2 :: [Int] -> String
solve2 [a, b]
  | a > b  = "a > b"
  | a < b  = "a < b"
  | a == b = "a == b"

main :: IO ()
main = getLine >>= putStrLn . solve2 . map read . words

solve2 :: [Int] -> String
solve2 [a, b] =
  case a `compare` b of
    LT -> "a < b"
    EQ -> "a == b"
    GT -> "a > b"
-}
