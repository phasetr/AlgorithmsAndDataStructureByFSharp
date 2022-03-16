{-
https://atcoder.jp/contests/agc009/submissions/15558783
-}
import Control.Monad (replicateM)
import qualified Data.ByteString.Char8 as BS
import Data.Maybe (fromJust)

solve :: [[Int]] -> Int -> Int
solve [] m = 0
solve (xy:xys) m = d + solve xys m' where
  x = head xy
  y = last xy
  n = (x + m) `mod` y
  d = if n == 0 then 0 else y - n
  m' = m + d

main :: IO ()
main = do
  n <- getInt
  xys <- getIntNList n
  print $ solve (reverse xys) 0
  where
    readInt = fst . fromJust . BS.readInt
    readIntList = map readInt . BS.words
    getInt = readInt <$> BS.getLine
    getIntList = readIntList <$> BS.getLine
    getIntNList n = map readIntList <$> replicateM (fromIntegral n) BS.getLine
