-- https://atcoder.jp/contests/tessoku-book/submissions/35005424
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import qualified Data.Vector.Unboxed as VU
import qualified Data.Bits as B

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main :: IO ()
main = do
  n <- getInt
  as <- getIntList
  let p = foldl1 B.xor as
      ans | p == 0 = "Second"
          | otherwise = "First"
  putStrLn ans
