-- https://atcoder.jp/contests/caddi2018b/submissions/23869669
import Data.Bool ( bool )
import Data.Char ( isSpace )
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector.Unboxed as V
main :: IO ()
main =
  readLn
  >>= (\n -> V.unfoldrN n (B.readInt . B.dropWhile isSpace) <$> B.getContents)
  >>= putStrLn . bool "second" "first" . V.any odd
