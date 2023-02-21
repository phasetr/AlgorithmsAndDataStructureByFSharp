-- https://atcoder.jp/contests/tessoku-book/submissions/38492830
import Control.Monad ( replicateM )
import qualified Data.ByteString.Char8 as C
import Data.List ( unfoldr )
import qualified Data.IntMap as M
import qualified Data.Vector as V

main :: IO ()
main = get >>= \(n:d:_) -> replicateM n get >>= print . sol d

get :: IO [Int]
get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

sol :: Int -> [[Int]] -> M.Key
sol d = fst . V.foldl' f (0,M.empty)
  . V.unsafeAccum V.snoc (V.replicate (d+1) V.empty) . map (\[x,y] -> (x,y))

f :: (Ord a, Num a) => (M.Key, M.IntMap a) -> V.Vector M.Key -> (M.Key, M.IntMap a)
f (a,m) u = case M.lookupMax m' of
  Nothing    -> (a,m')
  Just (k,v) -> (a+k,M.update (\v -> if v>1 then Just (v-1) else Nothing) k m')
  where m' = V.foldl' (\m y -> M.insertWith (+) y 1 m) m u
