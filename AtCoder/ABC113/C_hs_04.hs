-- https://atcoder.jp/contests/abc113/submissions/3538709
import Control.Monad ( replicateM )
import Data.List ( foldl', sort, unfoldr )
import qualified Data.ByteString.Char8 as B
import qualified Data.IntMap as M

main :: IO ()
main = do
  (n:m:_)<-map read.words<$>getLine::IO[Int]
  pys<-replicateM m $ unfoldr (B.readInt.B.dropWhile(==' '))<$>B.getLine::IO[[Int]]

  let mp = foldl' (\m (p:y:_,n)->M.alter (f (y,n)) p m) M.empty $ zip pys [1..]
  let ns = sort $ concatMap (\(p, m)-> zipWith (curry (\((_,c),n)->(c, (p,n)))) (M.toAscList m) [1..]) $ M.toAscList mp
  putStr $ unlines $ map g ns

f :: (M.Key, a) -> Maybe (M.IntMap a) -> Maybe (M.IntMap a)
f (y,n) Nothing = Just (M.singleton y n)
f (y,n) (Just m) = Just (M.insert y n m)

g :: (Show a1, Show a2) => (a3, (a1, a2)) -> [Char]
g (_,(p,x)) = drop (length $ show p) ("000000"++show p) ++ drop (length $ show x) ("000000"++show x)
