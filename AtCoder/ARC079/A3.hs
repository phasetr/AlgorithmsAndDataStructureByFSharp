{-
https://atcoder.jp/contests/abc068/submissions/22257243
-}
import qualified Data.ByteString.Char8 as C
import qualified Data.Vector.Unboxed as VU
import qualified Data.IntSet as S
import Data.Maybe (fromJust)

main :: IO ()
main = do
  [n, m] <- map read . words <$> getLine
  abs <- VU.replicateM m $ do
    [a, b] <- map (fst . fromJust . C.readInt) . C.words <$> C.getLine
    return (a, b)
  putStrLn $ if solve n abs then "POSSIBLE" else "IMPOSSIBLE"

solve :: Int -> VU.Vector (Int, Int) -> Bool
solve n abs = any (`S.member` toN) $ S.toList fromOne where
  (fromOne, toN) = VU.foldl' go (S.empty, S.empty) abs
  go (fromOne, toN) (a, b)
    | a == 1 = (S.insert b fromOne, toN)
    | b == n = (fromOne, S.insert a toN)
    | otherwise = (fromOne, toN)

