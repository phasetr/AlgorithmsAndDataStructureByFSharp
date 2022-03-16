{-
https://atcoder.jp/contests/agc028/submissions/18063940
-}
import Data.Char (isSpace)
import Data.List (unfoldr)
import qualified Data.ByteString.Char8 as B
main :: IO ()
main = print . solve . B.lines =<< B.getContents

solve :: [B.ByteString] -> Int
solve (nm:s:t:_) = if all f [0..g-1] then n*m `div` g else -1 where
  [n,m] = unfoldr (B.readInt . B.dropWhile isSpace) nm
  g = gcd n m
  f i = B.index s (n`div`g*i) == B.index t (m`div`g*i)
solve _ = error "not come here"
