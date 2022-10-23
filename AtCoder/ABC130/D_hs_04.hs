-- https://atcoder.jp/contests/abc130/submissions/24785723
import qualified Data.Vector.Unboxed as V

main :: IO ()
main = do
  [n ,k]  <- map read . words <$> getLine
  as <- map read . words <$> getLine
  print $ solve n k as

solve :: Int -> Int -> [Int] -> Int
solve n k as = solve' 0 (-1) (-1) where
  v = V.fromList as
  solve' j l r
    | j >= k = (n-r) + solve' (j - v V.! (l+1)) (l+1) r
    | r ==  n-1 = 0
    | otherwise = solve' (j + v V.! (r+1)) l (r+1)
