{-
Insertion sort
https://riptutorial.com/haskell/example/7551/insertion-sort
https://stackoverflow.com/questions/28550361/insertion-sort-in-haskell
https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/1/ALDS1_1_A
See also ../../AOJ/ALDS1/01A01.hs
-}
isort :: Ord a => [a] -> [a]
isort [] = []
isort (x:xs) = insert $ isort xs
  where
    insert [] = [x]
    insert (y:ys)
      | x < y = x : y : ys
      | otherwise = y : insert ys

main :: IO ()
main = do
  print $ isort [5,4,3,2,1] == [1,2,3,4,5]
  print $ isort [1..3] == [1..3]
