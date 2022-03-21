{-
https://atcoder.jp/contests/agc039/submissions/27320041
-}
import Data.List (group)

solve :: String -> Int -> Int
solve s k = if all (== head s) s then length s * k `div` 2
  else a0 + dt * (k-1)
  where
    f :: String -> Int
    f s = sum $ map ((`div` 2).length) $ group s
    a0 = f s
    a1 = f (s++s)
    dt = a1 - a0

main :: IO ()
main = do
  s <- getLine
  k <- readLn
  print $ solve s k
