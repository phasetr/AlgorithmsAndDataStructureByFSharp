-- https://atcoder.jp/contests/tessoku-book/submissions/36141746
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main :: IO ()
main = do
  [n, k] <- getIntList
  as <- getIntList
  let binarySearchAns func value l r
        | r - l < 0.0000005 = l
        | otherwise = binarySearchAns func value l' r'
          where m = (l + r) / 2
                mvalue = func m
                (l', r') | mvalue < value = (l, m)
                         | otherwise = (m, r)
  let giseki x = map (\a -> floor ((fromIntegral a) / x)) as
      gisekiTotal x = sum $ giseki x
  let l = binarySearchAns gisekiTotal k 1 (10^9)
  putStrLn . unwords . map show $ giseki l
