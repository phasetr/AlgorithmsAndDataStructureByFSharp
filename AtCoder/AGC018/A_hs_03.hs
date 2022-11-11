-- https://atcoder.jp/contests/agc018/submissions/3651803
import qualified Data.ByteString.Char8 as B
import Data.List ( unfoldr )
main :: IO ()
main = do
  [n,k] <- map read . words <$> getLine
  as <- unfoldr (B.readInt . B.dropWhile (== ' ')) <$> B.getLine
  putStrLn $ sol k as

sol :: Int -> [Int] -> String
sol k as
  | k <= m && k `mod` l == 0 = "POSSIBLE"
  | otherwise = "IMPOSSIBLE"
  where
    l = foldl1 gcd as
    m = maximum as
