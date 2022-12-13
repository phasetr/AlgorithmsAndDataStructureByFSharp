-- https://atcoder.jp/contests/abc048/submissions/18569163
import Data.Char ( isSpace )
import Data.List ( foldl', unfoldr )
import qualified Data.ByteString.Char8 as B
main :: IO ()
main = print . solve . unfoldr (B.readInt . B.dropWhile isSpace) =<< B.getContents

solve :: (Ord b, Num b) => [b] -> b
solve (n:x:as) = fst $ foldl' (f x) (0,0) as where
  f x (t,p) a = (t+c,a-c) where c = max (p+a-x) 0
solve _ = error "not come here"
