-- https://atcoder.jp/contests/abc085/submissions/1958026
import Control.Monad ( replicateM )
import Data.List ( sortBy )

main :: IO ()
main = do
  [n, h] <- map read . words <$> getLine
  (a, b) <- unzip <$> replicateM n (do
      [ai, bi] <- map read . words <$> getLine
      return (ai, bi)
    )
  let
    ma = maximum a
    b' = sortBy (flip compare) $ filter (> ma) b
    l = b' ++ repeat ma
    ans = length $ takeWhile (< h) $ scanl (+) 0 l
  print ans
