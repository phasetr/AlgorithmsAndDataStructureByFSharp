-- https://atcoder.jp/contests/abc085/submissions/13486797
import Control.Monad ( replicateM )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import Data.List ( sortOn, transpose )
import Data.Ord ( Down(Down) )

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main = do
  [n,h] <- getIntList
  [as,bs] <- transpose <$> replicateM n getIntList
  let amax = maximum as
      bls = takeWhile (>= amax) $ sortOn Down bs
      ans | sum bls >= h = length . takeWhile (< h) $ scanl (+) 0 bls
          | otherwise = (h - s - 1) `div` amax + 1 + length bls
          where s = sum bls
  print ans
