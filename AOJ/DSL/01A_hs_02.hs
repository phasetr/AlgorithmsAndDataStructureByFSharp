-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/DSL_1_A/review/2294433/aimy/Haskell
import Data.IntMap ((!))
import qualified Data.IntMap.Strict as M
import qualified Data.ByteString.Char8 as B
import Data.List ( foldl' )
import Data.Maybe ( fromJust )

untilFix :: Eq t => (t -> t) -> t -> t
untilFix f x = if f x == x then x else untilFix f (f x)

main :: IO ()
main = do
  [n,q] <- fmap (map read . words) getLine
  cxys <- fmap (map ((\[c,x,y]->(c,(x,y))) . map (fst . fromJust . B.readInt) . B.words) . B.lines) B.getContents
  mapM_ print (uft n q cxys)

uft :: Int -> Int -> [(Int,(Int,Int))] -> [Int]
uft n q = reverse . fst . foldl' process ([], M.fromDistinctAscList (zip [0..n-1] [0..]))

process :: (Eq a1, Num a1, Num a2) => ([a2], M.IntMap M.Key) -> (a1, (M.Key, M.Key)) -> ([a2], M.IntMap M.Key)
process (lg,m) (c,(x,y))
  | c==0 = (lg, M.insert (max x y) v1 (M.insert v2 v1 m))
  | c==1 = ((if v1==v2 then 1 else 0) : lg, m)
  where
    v1 = untilFix (m!) (min x y)
    v2 = untilFix (m!) (max x y)
process _ _ = error "not come here"
