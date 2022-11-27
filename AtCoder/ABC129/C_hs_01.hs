-- https://atcoder.jp/contests/abc129/submissions/24765049
import Control.Monad (replicateM)

main :: IO ()
main = do
  [n,m] <- map read . words <$> getLine
  am <- replicateM m readLn
  print $ solve am n

solve :: [Int] -> Int -> Int
solve am n = (\(a,b,c) -> a)
  $ foldl func (0,1,1) (am ++ [n+1])
  where
    func (a,b,k) l
      | k == l = (b,0,k+1)
      | otherwise = func (b,(a+b) `mod` (10^9+7),k+1) l
