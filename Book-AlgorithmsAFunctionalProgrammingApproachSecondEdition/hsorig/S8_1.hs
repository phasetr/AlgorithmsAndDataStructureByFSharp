module S8_1 where
import DivideAndConquer ( msort, qsort )

-- P.155, 8.1 Divide-and-conquer
main :: IO ()
main = do
  print $ msort l == [1,1,2,3,4,5,9]
  print $ qsort l == [1,1,2,3,4,5,9]
  where l = [3,1,4,1,5,9,2]
