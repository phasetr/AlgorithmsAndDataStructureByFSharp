-- https://atcoder.jp/contests/abc094/submissions/2377526
{-# OPTIONS_GHC -O2 -funbox-strict-fields #-}
import qualified Data.ByteString.Char8 as BC
import           Data.List             (delete, maximum, minimumBy)
import           Data.Maybe            (fromJust)
import           Data.Ord              (comparing)

main :: IO ()
main = do
  n <- readLn
  as <- getInts
  let (x, y) = solve n as
  putStrLn $ show x ++ " " ++ show y

solve :: Int -> [Int] -> (Int, Int)
solve n as = (x, y) where
  x = maximum as
  y = minimumBy (comparing (\a -> abs (a - x `div` 2))) $ delete x as

readInts :: BC.ByteString -> [Int]
readInts = map (fst . fromJust . BC.readInt) . BC.words

getInts :: IO [Int]
getInts = readInts <$> BC.getLine
