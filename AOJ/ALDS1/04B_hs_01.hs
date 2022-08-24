-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/all/ALDS1_4_B
import qualified Data.Vector as V
main :: IO ()
main = do
  n <- readLn
  ss <- fmap (V.fromList . map read . words) getLine
  getLine
  ts <- fmap (V.fromList . map read . words) getLine
  print $ solve n ss ts
bsearch :: Integral b => (b -> Bool) -> (b, b) -> b
bsearch c t = snd $ head $ dropWhile (\(l,u) -> u - l > 1) $ iterate f t  where
  f (l,u) = (\x -> if c x then (l,x) else (x,u)) $ div (l + u) 2
solve :: Int -> V.Vector Int -> V.Vector Int -> Int
solve n ss = V.foldl (\acc t -> if t == ss V.! bsearch (\x -> t <= ss V.! x) (-1,n) then acc+1 else acc) 0

test :: IO ()
test = do
  print $ solve 5 (V.fromList [1,2,3,4,5] :: V.Vector Int) (V.fromList [3,4,1]) == 3
  print $ solve 1 (V.fromList [3,1,2] :: V.Vector Int) (V.fromList [5]) == 0
  print $ solve 5 (V.fromList [1,1,2,2,3]) (V.fromList [1,2]) == 2
