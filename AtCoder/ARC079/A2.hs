{-
https://atcoder.jp/contests/abc068/submissions/29796228
-}
{-# OPTIONS_GHC -O2 #-}
import Data.List (unfoldr)
import Data.Char (isSpace)
import qualified Data.Array as A
import Control.Monad (replicateM)
import qualified Data.ByteString.Char8 as BS

main :: IO ()
main = do
  [n, m] <- unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine
  cs <- replicateM n . unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine
  putStrLn $ solve n cs

solve :: Int -> [[Int]] -> String
solve n cs = if check 1 n graph then "POSSIBLE" else "IMPOSSIBLE" where
  graph = toGraph n cs

  toGraph :: Int -> [[Int]] -> A.Array Int [Int]
  toGraph n cs = A.accumArray (flip (:)) [] (1, n) $ concatMap (\[a, b] -> [(a, b), (b, a)]) cs

  check :: Int -> Int -> A.Array Int [Int] -> Bool
  check a b graph = not $ null answer where
      answer = filter (\g -> a `elem` g && b `elem` g) $ A.elems graph
