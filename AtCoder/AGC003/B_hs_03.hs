-- https://atcoder.jp/contests/agc003/submissions/3123170
import Data.List ( groupBy )

main :: IO()
main = do
  n <- readLn :: IO Int
  as <- map read . lines <$> getContents :: IO [Integer]
  print $ (sum . map ((`div` 2) . sum) . filter (notElem 0) . groupBy (\a b -> a /= 0 && b /= 0)) as
