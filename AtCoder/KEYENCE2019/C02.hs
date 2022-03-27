{-
https://atcoder.jp/contests/keyence2019/submissions/4006764
-}
import Data.List (sort,partition)
main :: IO ()
main = do
  getLine
  as <- map read . words <$> getLine
  bs <- map read . words <$> getLine
  let
    ds = zipWith subtract bs as
    (ps', ns) = partition (>= 0) ds
    ps = reverse $ sort ps'
    d = sum ns
  print $ maybe (-1) (+ length ns) $ f 0 ps d

f :: Int -> [Integer] -> Integer -> Maybe Int
f k _ n | n >= 0 = Just k
f _ [] _ = Nothing
f k (m : ms) n = f (k + 1) ms (m + n)
