-- https://atcoder.jp/contests/tessoku-book/submissions/35854421
{-# LANGUAGE TypeApplications #-}
import Control.Monad (replicateM_)
import qualified Data.ByteString.Char8 as BS
import Data.Char (isSpace)
import Data.Maybe (fromJust)
import qualified Data.Vector.Algorithms.Intro as VAI
import qualified Data.Vector.Unboxed as VU

getInt :: IO Int
getInt = fst . fromJust . BS.readInt <$> BS.getLine

search :: Int -> (Int, Int) -> (Int -> Int) -> Int
search x (l, r) f
  | l > r = m + 1
  | x <= f m = search x (l, m - 1) f
  | otherwise = search x (m + 1, r) f
  where
    m = (l + r) `div` 2

solve :: Int -> VU.Vector Int -> Int
solve x as = search x (0, VU.length as - 1) (as VU.!)

main :: IO ()
main = do
  n <- readLn @Int
  as <- VU.unfoldrN n (BS.readInt . BS.dropWhile isSpace) <$> BS.getLine
  q <- readLn @Int

  let as' = VU.modify VAI.sort as

  replicateM_ q $ do
    x <- getInt
    print $ solve x as'
