-- https://atcoder.jp/contests/abc111/submissions/27755873
import Data.List (group,sort,sortBy,transpose)

splitRec :: Int -> [a] -> [[a]]
splitRec _ [] = []
splitRec n xs =
  h : splitRec n t where (h, t) = splitAt n xs

counting :: [Int] -> [(Int, Int)]
counting = (++[(0, 0)]) . sortBy (flip compare)
  . map (\es -> (length es, head es)) . group . sort

calc :: (Num c, Ord c, Eq a) => c -> [[(c, a)]] -> c
calc n [os, es] =
  if ov /= ev then n - oc - ec
  else min (n - oc - secondc es) (n - ec - secondc os)
  where
    (oc, ov) = head os
    (ec, ev) = head es
    secondc = fst . head . tail
calc n _ = undefined

main :: IO ()
main = calc <$> readLn
  <*> (map counting . transpose . splitRec 2
       . map (read :: String -> Int) . words <$> getLine)
  >>= print
