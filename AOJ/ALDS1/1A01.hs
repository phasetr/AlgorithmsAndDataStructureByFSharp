#!/usr/bin/env stack
-- stack script --resolver lts-16.0
-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ALDS1_1_A&lang=ja
-- http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid=2178139#1
main :: IO ()
main = do
  n <- read <$> getLine
  getLine >>=
    mapM_ putStrLn
    . map (unwords . map show)
    . ans n 0
    . map (read :: String -> Int) . words

ans n i x
  | n == i    = []
  | otherwise =
    let k = x!!i
        t = drop (i+1) x
        h = insSort k $ take i x
        r = h ++ t
    in
      (r:ans n (i+1) r)
  where
    insSort :: Int -> [Int] -> [Int]
    insSort k [] = [k]
    insSort k (x:xs)
      | k <= x    = (k:x:xs)
      | otherwise = x:(insSort k xs)
