#!/usr/bin/env stack
-- stack script --resolver lts-16.0
-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_1_D&lang=ja
main :: IO ()
main = do
  s1 <- readLn :: IO Int
  let s  = s1 `mod` 60
  let m  = s1 `div` 60 `mod` 60
  let h = s1 `div` 3600
  putStrLn $ (show h) ++ ":" ++ (show m) ++ ":" ++ (show s)
  -- printf "%d:%d:%d\n" h m s

{-
main = do
  s <- readLn :: IO Int
  putStrLn $ foldl1 (\x y -> x ++ ":" ++ y) $ map show [s `div` 3600, s `div` 60 `mod` 60, s `mod` 60]

main :: IO ()
main = readLn >>=
  putStrLn .
  foldl1 (\x y -> x ++ ":" ++ y) .
  map show .
  (\s -> [s `div` 3600, s `div` 60 `mod` 60, s `mod` 60])
-}
