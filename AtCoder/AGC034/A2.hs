{-
https://atcoder.jp/contests/agc034/submissions/17495044
-}
import Data.Bool (bool)
import Data.Char (isSpace)
import Data.List (unfoldr)
import qualified Data.ByteString.Char8 as B
main :: IO ()
main = putStrLn .
  bool "No" "Yes" . solve . B.lines
  =<< B.getContents

solve :: [B.ByteString] -> Bool
solve (ns:s:_) =
  f a c s && f b d s && (c<d || g (b-1) (d+1) s) where
  [n,a,b,c,d] = unfoldr (B.readInt . B.dropWhile isSpace) ns
  f i j = not . search "##" i j
  g i j = search "..." i j
  search t i j = B.isInfixOf (B.pack t) . B.drop(i-1) . B.take j
solve _ = error "not come here"

