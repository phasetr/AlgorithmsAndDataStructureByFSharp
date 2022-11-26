-- https://atcoder.jp/contests/agc023/submissions/15575407
import Data.Char ( isSpace )
import Data.List ( group, sort, unfoldr )
import qualified Data.ByteString.Char8 as B
main :: IO ()
main = print . solve . unfoldr (B.readInt . B.dropWhile isSpace) =<< B.getContents
solve :: (Ord a, Num a) => [a] -> Int
solve (n:as) = sum $ map (f . length) . group . sort . scanr(+) 0 $ as where
  f i = i*(i-1) `div` 2
solve _ = error "not come here"
