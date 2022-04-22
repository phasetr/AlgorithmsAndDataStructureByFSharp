module Selection where
import Data.List (minimum, minimumBy, delete, unfoldr)

-- See ../../AOJ/ALDS1/02B01.hs
-- https://riptutorial.com/haskell/example/12246/selection-sort
ssort1 :: Ord t => [t] -> [t]
ssort1 [] = []
ssort1 xs = x : ssort1 (delete x xs) where x = minimum xs

ssort2 :: [Int] -> [Int]
ssort2 xs = foldl f xs [0..n]
  where
    n = length xs - 2
    f xs i = as++ys where
        (as,bs) = splitAt i xs
        ys = swap bs $ minIndex bs
swap :: [a] -> Int -> [a]
swap xs minj = if minj>0 then m:ys++y:zs else xs
  where (y:ys,m:zs) = splitAt minj xs
minIndex :: [Int] -> Int
minIndex xs = head . map fst
  . filter (\e -> snd e == minimum xs) $ zip [0..] xs

main :: IO ()
main = do
  print $ ssort1 [5,6,4,2,1,3] == [1..6]
  print $ ssort2 [5,6,4,2,1,3] == [1..6]
