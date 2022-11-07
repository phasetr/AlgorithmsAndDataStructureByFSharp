-- https://atcoder.jp/contests/agc011/submissions/13485442
import Control.Monad ()
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import Data.List ( sortOn )
import Data.Ord ( Down(Down) )

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main = do
  n <- getInt
  as <- sortOn Down <$> getIntList
  print . succ . length . takeWhile id $ zipWith (\a s -> a <= 2 * s) as (tail (scanr (+) 0 as))
