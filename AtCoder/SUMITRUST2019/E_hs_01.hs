-- https://atcoder.jp/contests/sumitrust2019/submissions/15668453
import Data.Char ( isSpace )
import Data.List ( unfoldr )
import qualified Data.ByteString.Char8 as B
import qualified Data.IntMap as IM
main :: IO ()
main =
  getLine >> B.getContents >>=
  print . solve . unfoldr (B.readInt . B.dropWhile isSpace)

solve :: Foldable t => t IM.Key -> Integer
solve as = fst $ foldl f (1, IM.singleton (-1) 3) as

f :: (Integer, IM.IntMap Integer) -> IM.Key -> (Integer, IM.IntMap Integer)
f (k,m) a = (k*max (g (a-1) m - g a m) 0 `mod` (10^9+7), IM.insertWith(+)a 1 m)
  where g = IM.findWithDefault 0
