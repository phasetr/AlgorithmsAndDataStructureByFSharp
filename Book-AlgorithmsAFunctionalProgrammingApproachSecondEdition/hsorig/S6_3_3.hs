module S6_3_3 where
import qualified Sort as S
-- | P.119, QuickSort
-- naive implementation
-- For more efficient implementation, see qsort in Sort.hs
qsort :: (Ord a) => [a] -> [a]
qsort [] = []
qsort (pivot:rest) = qsort lower ++ [pivot] ++ qsort upper where
  lower = [ x | x <- rest, x<= pivot]
  upper = [ x | x <- rest, x > pivot]

-- | improved implementation
qsort' :: (Ord a) => [a] -> [a] -> [a]
qsort' [] s = s
qsort' (pivot:rest) s = qsort' lower (pivot : qsort' upper s) where
  lower = [ x | x <- rest, x<= pivot]
  upper = [ x | x <- rest, x > pivot]

main :: IO ()
main = print $ qsort ex == [1,1,2,3,4,5,8,9]
  && qsort ex == qsort' ex []
  && qsort ex == S.qsort ex
  where ex = [3,1,4,1,5,9,2,8]
