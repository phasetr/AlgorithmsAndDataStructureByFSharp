-- https://atcoder.jp/contests/abc160/submissions/11310574
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import Data.List ( sort )

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main = do
  [x, y, a, b, c] <- getIntList
  ps <- take x . reverse . sort <$> getIntList
  qs <- take y . reverse . sort <$> getIntList
  rs <- reverse . sort <$> getIntList
  let xs = sort (ps ++ qs)
  let s = sum $ zipWith max xs rs
  let t = sum $ drop (min c (a + b)) xs
  print $ s + t
