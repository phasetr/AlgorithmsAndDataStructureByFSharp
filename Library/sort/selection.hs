import Data.List (minimum, minimumBy, delete, unfoldr)

-- https://riptutorial.com/haskell/example/12246/selection-sort
ssort1 :: Ord t => [t] -> [t]
ssort1 [] = []
ssort1 xs = x : ssort1 (delete x xs) where x = minimum xs
