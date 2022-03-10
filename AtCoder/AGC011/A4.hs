{-
https://atcoder.jp/contests/agc011/submissions/8979187
-}
import Data.List (sort)

main :: IO ()
main = do
    [n,c,k] <- map read . words <$> getLine :: IO [Int]
    ts <- sort . map read . lines <$> getContents :: IO [Int]
    print $ solve c k ts

solve :: Int -> Int -> [Int] -> Int
solve c k ts =
  (\(bus,_,_) -> bus+1) $ foldl f (0,1,head ts) (tail ts) where
  f (bus,pssg,acct) t
    | pssg == c  = (bus+1,1,t)
    | acct+k < t = (bus+1,1,t)
    | otherwise = (bus,pssg+1,acct)
