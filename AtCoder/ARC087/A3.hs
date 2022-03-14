{-
https://atcoder.jp/contests/abc082/submissions/27597006
-}
import Data.List (foldl',group,sort)

main :: IO ()
main = interact $ show . solve . map read . tail . words

solve :: [Int] -> Int
solve = foldl' f 0 . group . sort where
  f s bs = s + (if l<b then l else l-b) where
    l = length bs
    b = head bs
