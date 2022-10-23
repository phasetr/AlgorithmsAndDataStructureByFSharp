-- https://atcoder.jp/contests/abc130/submissions/5965952
import qualified Data.Set as S

main :: IO ()
main = do
  [n,k] <- map read . words <$> getLine
  as <- map read . words <$> getLine
  print $ solve n k as

solve :: Int -> Int -> [Int] -> Int
solve n k as = sum $ map f sl where
  sl = scanl (+) 0 as
  ss = S.fromList sl
  f s = indexLE (s-k) ss

indexLE :: Int -> S.Set Int -> Int
indexLE s set = fromIntegral $ S.size s1 where
  (s1,_) = S.split (s+1) set
