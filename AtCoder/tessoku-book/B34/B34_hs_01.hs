-- https://atcoder.jp/contests/tessoku-book/submissions/35005897
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import qualified Data.Bits as B

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main :: IO ()
main = do
  [n, x, y] <- getIntList
  as <- getIntList
  let grundy :: Int -> Int
      grundy k = [0,0,1,1,2] !! (k `mod` 5)
  let p = foldl1 B.xor $ map grundy as
      ans | p == 0 = "Second"
          | otherwise = "First"
  putStrLn ans
