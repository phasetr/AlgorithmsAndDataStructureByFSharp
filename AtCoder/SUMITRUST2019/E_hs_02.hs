-- https://atcoder.jp/contests/sumitrust2019/submissions/14368173
import Control.Monad ()
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import Data.List ( foldl' )

main :: IO ()
main = do
  getLine
  as <- map (fst . fromJust . BS.readInt) . BS.words <$> BS.getLine
  print . (\(x,_,_,_) -> x) $ foldl' solve (1,0,0,0) as

solve :: (Num a, Eq a) => (Int, a, a, a) -> a -> (Int, a, a, a)
solve (s,a,b,c) d
  | a == d = (s',a+1,b,c)
  | b == d = (s',a,b+1,c)
  | c == d = (s',a,b,c+1)
  | otherwise = (s',a,b,c)
  where s' = s * length (filter (== d) [a,b,c]) `mod` 1000000007
