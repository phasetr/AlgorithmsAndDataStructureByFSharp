{-
https://atcoder.jp/contests/abc118/submissions/4554091
-}
import Data.Maybe (fromJust)
import qualified Data.ByteString.Char8 as C8
main :: IO ()
main = do
  _  <- getLine
  as <- fmap (map (fst . fromJust . C8.readInt) . C8.words) C8.getLine
  print $ foldl1 gcd as
