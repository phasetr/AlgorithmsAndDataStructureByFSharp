{-
https://atcoder.jp/contests/agc011/submissions/1157325
-}
import Control.Monad (replicateM)
import Data.List (sort)

main :: IO ()
main = do
  [n,c,k] <- map read . words <$> getLine
  replicateM n (read <$> getLine) >>= print . solve c k

solve :: Int -> Int -> [Int] -> Int
solve c k ts = f 0 $ sort ts where
  f b [] = b
  f b (x:xs) = f (b+1) (drop (length es) xs) where
    ds = takeWhile (\y -> y <= x + k) xs
    es = take (c-1) ds
