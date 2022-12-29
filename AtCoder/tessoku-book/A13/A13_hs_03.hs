-- https://atcoder.jp/contests/tessoku-book/submissions/35887335
{-# LANGUAGE TypeApplications #-}
import Data.Array.Unboxed (UArray, listArray, (!))
import qualified Data.ByteString.Char8 as BS
import Data.Char (isSpace)
import Data.List (scanl', unfoldr)

getInts :: IO [Int]
getInts = unfoldr (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine

main :: IO ()
main = do
  [n, k] <- getInts
  as <- getInts

  let as' = listArray @UArray (1, n) as

  let f r p = last $ takeWhile (\i -> (as' ! i) - (as' ! p) <= k) [r .. n]
      ps = drop 1 $ scanl' f 1 [1 .. n]
  print $ sum $ zipWith (-) ps [1 ..]
