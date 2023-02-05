-- https://atcoder.jp/contests/tessoku-book/submissions/35713397
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main :: IO ()
main = do
  [n, l] <- getIntList
  k <- getInt
  as <- (0 :) . (++ [l]) <$> getIntList
  let ds = zipWith (-) (tail as) as
  let check x xs = g 0 xs >= (k+1)
        where
          g _ [] = 0
          g s (y:ys) | s+y >= x = 1 + g 0 ys
                     | otherwise = g (s+y) ys
  let binarySearch = bs 0 l
        where
          bs lidx ridx
            | ridx - lidx == 1 = lidx
            | midv = bs midx ridx
            | otherwise = bs lidx midx
            where
              midx = (ridx + lidx) `div` 2
              midv = check midx ds
  print binarySearch
