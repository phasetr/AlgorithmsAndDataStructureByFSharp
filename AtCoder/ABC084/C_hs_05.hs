-- https://atcoder.jp/contests/abc084/submissions/1924906
import Control.Monad ( forM_, replicateM )
import Data.List ( foldl' )

main :: IO ()
main = do
  n <- readLn
  a <- map (map read . words) <$> replicateM (n - 1) getLine
  forM_ [0..n-1] $ \i -> print $ solve (drop i a)

solve :: [[Int]] -> Int
solve = foldl' f 0 where
  f curr [c, s, f] = max s ((curr + f - 1) `div` f * f) + c
  f _ _ = error "not come here"
