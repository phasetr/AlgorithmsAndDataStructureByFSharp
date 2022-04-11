-- https://atcoder.jp/contests/dp/submissions/6110258
import Control.Monad (replicateM)

solve :: [(Int,Int,Int)] -> Int
solve = (\(a,b,c) -> max a (max b c)) . foldl1 f where
  f (a,b,c) (a',b',c') = (a'+max b c, b'+max c a, c'+max a b)

main :: IO ()
main = readLn
  >>= flip replicateM ((\[a,b,c] -> (a,b,c)) . map read . words <$> getLine)
  >>= print . solve
