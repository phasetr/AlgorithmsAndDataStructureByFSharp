-- https://atcoder.jp/contests/dp/submissions/26333970
import qualified Data.ByteString.Char8 as BS
import Data.Char (isSpace)
import Data.List (unfoldr)

main :: IO ()
main = do
  li <- BS.getLine
  let Just (n,_) = BS.readInt li
  co <- BS.getContents
  let abcs = map (unfoldr (BS.readInt . BS.dropWhile isSpace)) $ BS.lines co
  print $ loop 0 0 0 abcs

loop :: Int -> Int -> Int -> [[Int]] -> Int
loop a b c [] = max a (max b c)
loop a b c ([ai,bi,ci]:abcs) = loop an bn cn abcs where
  an = ai + max b c
  bn = bi + max c a
  cn = ci + max a b
loop _ _ _ _ = undefined

{-
前日にした活動それぞれについて、最大の幸福度を記録する。
翌日に、違う活動をして得られる最大の幸福度を求める。
-}
