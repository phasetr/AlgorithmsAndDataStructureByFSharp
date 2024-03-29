{-
https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/all/ALDS1_2_A
See also ../../Library/sort/bubble.hs,
../../Library/sort/bubble.fsx
-}
bsort :: [Int] -> ([Int],Int)
bsort xs = loop (True,xs,0) where
  n = length xs - 2 -- for j in [N-1..1]
  loop (False,xs,m) = (xs,m)
  loop (True,xs,m) = loop $ foldr swap (False,xs,m) [0..n]
  swap i (k,xs,m) =
    if c < b
    then (True, sorted++c:b:ds,   m+1)
    else (k,    sorted++unsorted, m)
    where (sorted,unsorted@(b:c:ds)) = splitAt i xs

main :: IO ()
main = do
  getLine
  xs <- fmap (map read . words) getLine
  let (ys,m) = bsort xs
  putStrLn $ unwords $ map show ys
  print m

test = do
--  print $ foldr swap (False,[5,3,2,4,1],0) [0..3] == (True,[1,5,3,2,4],4)
--  print $ foldr swap (True,[1,5,3,2,4],4) [0..3] == (True,[1,2,5,3,4],6)
--  print $ foldr swap (True,[1,2,5,3,4],6) [0..3] == (True,[1,2,3,5,4],7)
--  print $ foldr swap (True,[1,2,3,5,4],7) [0..3] == (True,[1,2,3,4,5],8)
--  print $ foldr swap (True,[1,2,3,4,5],8) [0..3] == (True,[1,2,3,4,5],8)
--  print $ loop ()
  print $ bsort [5,3,2,4,1] == ([1..5],8)
  print $ bsort [5,2,4,6,1,3] == ([1..6],9)
