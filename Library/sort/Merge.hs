module Merge where
{-
Merge sort
https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/all/ALDS1_5_B
https://qiita.com/ymmy02/items/3fbab0ca3518ae19b7d6

See also ../../AOJ/ALDS1/05B01.hs
-}
msort1 :: Ord a1 => [a2] -> [a1]
msort1 l = merge (msort1 ll) (msort1 rl) where
  n = length l `div` 2
  (ll,rl) = splitAt n l

  merge :: Ord a => [a] -> [a] -> [a]
  merge ll rl = help [] ll rl where
    help ml [] rl = reverse ml ++ rl
    help ml ll [] = reverse ml ++ ll
    help ml ll@(l:ls) rl@(r:rs)
      | l <= r    = help (l:ml) ls rl
      | otherwise = help (r:ml) ll rs

merge :: Ord a => [a] -> [a] -> [a]
merge xs [] = xs
merge [] ys = ys
merge ll@(x:xs) rl@(y:ys)
  | x < y     = x : merge xs rl
  | otherwise = y : merge ll ys

msort2 :: Ord a => [a] -> [a]
msort2 []  = []
msort2 [x] = [x]
msort2 xs  = merge (msort2 left) (msort2 right) where
  (left,right) = splitAt (length xs `div` 2) xs

msort3 :: Ord a => [a] -> [a]
msort3 [] = []
msort3 xs = go [[x] | x <- xs] where
  go [a] = a
  go xs = go (pairs xs)
  pairs (a:b:t) = merge a b : pairs t
  pairs t = t

main :: IO ()
main = do
  --Stack Overflow: needs strict
  --print $ msort1 [8,5,9,2,6,3,7,1,10,4] == [1..10]
  print $ merge ll rl
  print $ msort2 [1,8,7,6,2,5,9,4,0,3] == [0..9]
  print $ msort3 [1,8,7,6,2,5,9,4,0,3] == [0..9]
  where
    l = [8,5,9,2,6,3,7,1,10,4]
    n = length l `div` 2
    (ll,rl) = splitAt n l
