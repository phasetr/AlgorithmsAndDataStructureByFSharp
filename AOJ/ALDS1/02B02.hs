-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_B/review/2416378/napo/Haskell
import Data.List ( elemIndex )
import Data.Maybe ( fromJust )

main :: IO()
main = getLine >> getLine >>= putStr . solve . (++[1000])
  . map read . words

solve :: [Integer] -> String
solve = form . f where
  form xs = unlines [(unwords . map show . init) xs, show $ last xs -1000]
  f xs = let n = minimum xs in g n xs where
    g _ [] = []
    g m ys@(z:zs)
      | m == z = (z:) $f zs
      | otherwise = let s = fromJust $ elemIndex m ys
                    in f $ ((++ [last ys +1]) . (m:) . tail . init)
                       $ take s ys ++ [z] ++ drop (s+1) ys

test = do
  print $ solve [5,6,4,2,1,3]
  print $ solve [5,2,4,6,1,3]
