-- https://atcoder.jp/contests/tessoku-book/submissions/35817431
{-# LANGUAGE TypeApplications #-}
import Data.Array.Unboxed (UArray, bounds, listArray, (!))
import qualified Data.ByteString.Char8 as BS
import Data.Char (isSpace)
import Data.List (unfoldr)
import Data.Maybe ( fromMaybe )

getInts :: IO [Int]
getInts = unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine

search :: Int -> (Int, Int) -> UArray Int Int -> Maybe Int
search x (l, r) as
  | l > r = Nothing
  | x < as ! m = search x (l, m - 1) as
  | x == as ! m = Just m
  | otherwise = search x (m + 1, r) as
  where m = (l + r) `div` 2

main :: IO ()
main = do
  [n, x] <- getInts
  as <- getInts
  let as' = listArray @UArray @Int (1, n) as
  print $ fromMaybe (- 1) (search x (bounds as') as')
