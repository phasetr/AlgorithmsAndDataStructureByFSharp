{-# LANGUAGE TupleSections #-}
{-
https://atcoder.jp/contests/abc082/submissions/15856453
-}
import Data.Char (isSpace)
import Data.List (unfoldr)
import qualified Data.ByteString.Char8 as B
import qualified Data.IntMap as IM
main :: IO ()
main = print .
  solve . tail . unfoldr (B.readInt . B.dropWhile isSpace)
  =<< B.getContents

solve :: [IM.Key] -> IM.Key
solve = IM.foldrWithKey f 0
  . IM.fromListWith (+) . map (, 1) where
  f k v r = r + if k>v then v else v-k
