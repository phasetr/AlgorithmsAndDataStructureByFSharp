{-
See also ../../Library/sort/insertion.hs
https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/1/ALDS1_1_A
```
// トランプでのカードの入れ替えと同じ方式
insertionSort(A, N) // N個の要素を含む0-オリジンの配列A
   for i が 1 から N-1 まで
     v = A[i]
     j = i - 1
     while j >= 0 かつ A[j] > v
       A[j+1] = A[j]
       j--
     A[j+1] = v
```
-}
solve :: Int -> [Int] -> [[Int]]
solve n xs = foldl f [xs] [1..n-1]
  where
    f l i = insertion i (head l) : l
    insertion i xs =
      smallerThanV ++ [v] ++ largerThanV ++ iThAndAfter
      where
        v = xs !! i
        p = take i xs
        smallerThanV = [x | x <- p, x <= v]
        largerThanV = [x | x <- p, v < x]
        iThAndAfter = drop (i + 1) xs

main :: IO ()
main = do
  n <- readLn
  xs <- fmap (map read . words) getLine
  mapM_ (putStrLn . unwords . map show) $ reverse $ solve n xs

test :: IO ()
test = do
  print $ reverse (solve 6 [5,2,4,6,1,3]) ==
    [[5,2,4,6,1,3]
    ,[2,5,4,6,1,3]
    ,[2,4,5,6,1,3]
    ,[2,4,5,6,1,3]
    ,[1,2,4,5,6,3]
    ,[1,2,3,4,5,6]]
  print $ reverse (solve 3 [1,2,3]) ==
    [[1,2,3]
    ,[1,2,3]
    ,[1,2,3]]
