{-
Insertion sort
https://riptutorial.com/haskell/example/7551/insertion-sort
See also ../AOJ/ALDS1/1A01.hs
-}
isort :: Ord a => [a] -> [a]
isort [] = []
isort (x:xs) = insert x (isort xs)
  where
    insert :: Ord a => a -> [a] -> [a]
    insert x [] = [x]
    insert x (y:ys) | x < y     = x:y:ys
                    | otherwise = y:insert x ys
-- isort [5,4,3,2,1] == [1,2,3,4,5]
