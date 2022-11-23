-- https://atcoder.jp/contests/diverta2019-2/submissions/5923787
import Data.List ( sort )

count :: (Eq t, Num a) => t -> [a] -> [t] -> [a]
count _ is [] = is
count p (i:is) (x:xs)
  | p == x = count x (i+1:is) xs
  | otherwise = count x (1:i:is) xs
count _ _ _ = error "not come here"

main :: IO ()
main = do
  n <- readLn
  xs <- sort . map (map read . words) . lines <$> getContents
  let ds = [zipWith (-) (xs !! i) (xs !! j) | i <- [0..n-1], j <- [0..n-1], i > j]
  print . (n -) . maximum $ count [] [0] (sort ds)
