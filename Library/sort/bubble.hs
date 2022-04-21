{-
See ../../AOJ/ALDS1/02D01.hs
選択ソートとの比較: 安定ソートか否か
-}
-- https://qiita.com/7shi/items/1e2a66bf8e8c7f0bd70f
bsort :: Ord a => [a] -> [a]
bsort [] = []
bsort xs = y : bsort ys where (y:ys) = bswap xs

bswap :: Ord a => [a] -> [a]
bswap []  = []
bswap [x] = [x]
bswap (x:xs)
  | x > y     = y:x:ys
  | otherwise = x:y:ys
  where (y:ys) = bswap xs

main :: IO ()
main = do
  print $ bswap [4,3,1,5,2] == [1,4,3,2,5]
  print $ bswap [4,3,2,5]   == [2,4,3,5]
  print $ bswap [4,3,5]     == [3,4,5]
  print $ bsort [4,3,1,5,2] == [1..5]
  print $ bsort [5,4,3,2,1] == [1..5]
  print $ bsort [4,6,9,8,3,5,1,7,2] == [1..9]
