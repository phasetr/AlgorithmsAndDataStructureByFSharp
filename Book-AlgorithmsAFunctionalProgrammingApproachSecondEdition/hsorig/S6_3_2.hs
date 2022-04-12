module S6_3_2 where
-- Insertion Sort
import qualified Sort as S

-- | P.119, naive implementation
-- For more efficient implementation, see isort in Sort.hs
isort :: (Foldable t, Ord a) => t a -> [a]
isort = foldr insert []

-- | P.119
insert :: (Ord a) => a -> [a] -> [a]
insert x xs = takeWhile (<= x) xs ++ [x] ++ dropWhile (<=x) xs

main :: IO ()
main = print $ isort ex == [1,1,2,3,4,5,8,9]
  && isort ex == S.isort ex
  where ex = [3,1,4,1,5,9,2,8]
