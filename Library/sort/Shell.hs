module Shell where
import Data.List ( transpose, unfoldr )
import Insertion ( isort2 )
-- https://en.wikibooks.org/wiki/Algorithm_Implementation/Sorting/Shell_sort#Haskell
-- | Splits a list into k columns.
columnize :: Int -> [a] -> [[a]]
columnize k = transpose . takeWhile (not . null) . unfoldr (Just . splitAt k)

-- | Merges columns back into a single list.
decolumnize :: [[a]] -> [a]
decolumnize = concat . transpose

-- | Each phase of the Shell sort breaks the list into k columns, sorts each with an
-- insertion sort, then merges those columns back into a list.
shellSortPhase :: (Ord a) => Int -> [a] -> [a]
shellSortPhase k = decolumnize . map isort2 . columnize k

-- | The full Shell sort, applying phases with arbitrarily large gap sizes according to
-- R. Sedgewick, J. Algorithms 7 (1986), 159-173
shellSort :: (Ord a) => [a] -> [a]
shellSort xs = foldr shellSortPhase xs gaps where
  gaps = takeWhile (< length xs) sedgewick
  sedgewick = concat [[9 * 2^n - 9 * 2^(n `div` 2) + 1,
                        8 * 2^(n+1) - 6 * 2^(n `div` 2) + 1] | n <- [0..]]

main :: IO ()
main = do
  print $ shellSort [5,4..1] == [1,2,3,4,5]
  print $ shellSort [1..3] == [1..3]
  print $ columnize 2 [1..10] == [[1,3,5,7,9],[2,4,6,8,10]]
  print $ columnize 3 [1..10] == [[1,4,7,10],[2,5,8],[3,6,9]]
  print $ decolumnize (columnize 2 [1..10]) == [1..10]
  print $ shellSortPhase 3 [10,9..1] == [1,3,2,4,6,5,7,9,8,10]
  print $ shellSortPhase 1 [1,3,2,4,6,5,7,9,8,10] == [1..10]
