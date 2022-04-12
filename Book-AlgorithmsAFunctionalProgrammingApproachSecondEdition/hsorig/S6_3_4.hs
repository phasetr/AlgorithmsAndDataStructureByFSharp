module S6_3_4 where
import qualified Sort as S

-- | P.120, Merge Sort
-- naive implementation,
-- for more efficient implementation, see msort in Sort.hs
msort :: (Ord a) => [a] -> [a]
msort [] = []
msort [x] = [x]
msort l = merge (msort l1)(msort l2) where
  l1 = take k l
  l2 = drop k l
  k  = length l `div` 2

merge :: (Ord a) => [a] -> [a] -> [a]
merge [] b = b
merge a [] = a
merge a@(x:xs) b@(y:ys)
  | x<=y      = x : merge xs b
  | otherwise = y : merge a ys

-- | P.121 improved implementation
msort' :: (Ord a) => [a] -> [a]
msort' [] = []
msort' [x] = [x]
msort' l = merge (msort' l1) (msort' l2) where
  l1 = take k l
  l2 = drop k l
  k  = length l `div` 2

main :: IO ()
main = print $ msort ex == [1,1,2,3,4,5,8,9]
  && msort ex == msort' ex
  && msort ex == S.msort ex
  where ex = [3,1,4,1,5,9,2,8]
