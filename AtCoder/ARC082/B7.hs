{-# OPTIONS_GHC -O2 -funbox-strict-fields #-}
{-
https://atcoder.jp/contests/abc072/submissions/3109336
-}
import qualified Data.ByteString.Char8 as BS
import           Data.List             (group)
import           Data.Maybe            (fromJust)

main :: IO ()
main = do
  n <- readLn
  ps <- map readInt . BS.words <$> BS.getLine
  print $ solve n ps

solve :: Int -> [Int] -> Int
solve n = sum . map count . group . zipWith (==) [1 .. n]

count :: [Bool] -> Int
count xs
  | head xs   = (length xs + 1) `div` 2
  | otherwise = 0

readInt :: BS.ByteString -> Int
readInt = fst . fromJust . BS.readInt
