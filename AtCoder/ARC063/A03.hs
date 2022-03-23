-- https://atcoder.jp/contests/abc047/submissions/30161397
import qualified Data.ByteString.Char8 as BS
main :: IO ()
main = do
  s <- BS.getLine
  print $ solve s

solve :: BS.ByteString -> Int
solve s = length $ filter id $ BS.zipWith (/=) s $ BS.tail s
