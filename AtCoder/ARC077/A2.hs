{-
https://atcoder.jp/contests/abc066/submissions/15253093
-}
import qualified Data.ByteString.Char8 as BS
import qualified Data.Vector.Unboxed as VU

main :: IO ()
main = BS.interact $ put . solve . get

get :: BS.ByteString -> VU.Vector Int
get = VU.unfoldr (BS.readInt . BS.dropWhile (<'0'))

put :: VU.Vector Int -> BS.ByteString
put = BS.pack . unwords . map show . VU.toList

solve :: VU.Vector Int -> VU.Vector Int
solve v = VU.generate n ((u VU.!) . f)
  where
    n = VU.head v
    u = VU.tail v
    f i = abs (2*i-n) - if i<(n+1) `div` 2 then 1 else 0
