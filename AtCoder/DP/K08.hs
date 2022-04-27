-- https://atcoder.jp/contests/dp/submissions/4090149
import Data.List ( foldl', unfoldr )
import qualified Data.ByteString.Char8 as B
import qualified Data.IntSet as S
main :: IO ()
main = do
  [n,k] <- map read . words <$> getLine
  as <- unfoldr (B.readInt . B.dropWhile (<'!')) <$> B.getLine
  putStrLn $ if S.member k $ f k as then "First" else "Second"

f :: S.Key -> [S.Key] -> S.IntSet
f k as = foldl' p S.empty [0..k] where
  p s i | S.member i s = s
        | otherwise = S.union s $ S.fromAscList $ filter (<=k) $ map (+i) as
