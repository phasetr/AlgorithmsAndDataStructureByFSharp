-- https://atcoder.jp/contests/abc147/submissions/15245897
import Control.Monad ( forM, filterM )
main :: IO ()
main = do
  n <- read <$> getLine
  xy <- forM [1..n] $ \i -> do
    a <- read <$> getLine
    forM [1..a] $ \j -> do
      [x,y] <- map read . words <$> getLine -- y_{ij} = 1 <=> 人x_{ij}が正直,y_{ij} = 0 <=> 人x_{ij}の発言の真偽は不明
      return (x,y)
  let oks = filter (ok xy) (powerset [1..n])
  print $ maximum $ fmap length oks

powerset :: [Int] -> [[Int]]
powerset = filterM (const [True,False])

ok :: [[(Int,Int)]] -> [Int] -> Bool
ok xys kinds = and [(y == 0) /= (x `elem` kinds) | i <- kinds,(x,y) <- xys !! (i-1)]

test = do
  print $ filterM (const [True,False]) [1..3]
