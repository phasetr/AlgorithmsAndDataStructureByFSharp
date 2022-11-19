-- https://atcoder.jp/contests/abc147/submissions/23820111
import Control.Monad ( replicateM )

main :: IO ()
main = do
  n <- readLn :: IO Int
  ts <- replicateM n $ do
    an <- readLn
    replicateM an $ do
      [x, y] <- map read . words <$> getLine
      return (x, y)
  print $ solve n ts

solve :: Int -> [[(Int, Int)]] -> Int
solve n ts = maximum $ map go $ replicateM n [True, False] where
  go :: [Bool] -> Int
  go ps
    | honests == length (filter id ps) = honests
    | otherwise = 0
    where
      honests = length $ filter correct $ filter snd $ zip [1..] ps
      correct (i, _) = all (\(x, y) -> if y == 1 then ps !! (x - 1) else not $ ps !! (x - 1)) $ ts !! (i-1)
