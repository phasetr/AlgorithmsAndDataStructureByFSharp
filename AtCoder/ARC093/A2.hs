{-
https://atcoder.jp/contests/arc093/submissions/18204446
-}
import Data.Char (isSpace)
import Data.List (unfoldr)
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector.Unboxed as V

main :: IO ()
main = mapM_ print
  . solve . unfoldr (B.readInt . B.dropWhile isSpace)
  =<< B.getContents

solve :: [Int] -> [Int]
solve (n:as) = map g [1..n] where
  bs = V.fromListN (n+2) $ 0:as++[0]
  t = V.sum $ (V.zipWith f =<< V.tail) bs
  f a b = abs $ a-b
  g i = t - f a b - f b c + f a c
    where [a,b,c] = map (bs V.!) [i-1..i+1]
solve _ = error "do not come here"
