-- https://atcoder.jp/contests/tessoku-book/submissions/35600499
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import Data.List ( sort, sortOn )
import Data.Ord ( Down(Down) )

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main = do
  n <- getInt
  as <- sort <$> getIntList
  bs <- sortOn Down <$> getIntList
  print . sum $ zipWith (*) as bs
