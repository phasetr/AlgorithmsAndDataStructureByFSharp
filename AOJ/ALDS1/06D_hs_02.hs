-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_D/review/3355881/showzaemon/Haskell
import Data.List ( sort )
import qualified Data.Sequence as S
import qualified Data.ByteString.Char8 as B
import Data.Maybe ( fromJust )
import qualified Data.Map as M

solve :: [Int] -> Int
solve l = iter cycles where
  iter [] = 0
  iter (c:cs) = cost c + iter cs

  cost = iter 0 0 maxBound where
      iter c s m [] -- c: length of this cycle, s:sum of this cycle, m: minimum in this cycle.
        | c < 2 = s
        | otherwise = s + min (m*(c-2)) (ma*(c+1) + m)
      iter c s m (x:xs) = iter (c+1) (s+x) (min m x) xs

  sl = sort l
  ma = head sl  -- minimum in all
  permutation = M.fromList $ zip l sl

  cycles = iter [] l where
    iter cl [] = cl
    iter cl (x:xs)
      | x `elem` ul = iter cl xs
      | otherwise = iter (cycle:cl) xs where
          ul = concat cl
          cycle = iter [x] where
            iter cl@(c:cs)
              | v == c = []
              | v `elem` cl = cl
              | otherwise = iter (v:cl) where
                  v =  permutation M.! c
            iter _ = error "undefined"

main :: IO()
main = do
  _ <- getLine -- fmap (fst . fromJust . B.readInt) B.getLine
  l <- fmap (map (fst . fromJust . B.readInt) . B.words) B.getLine
  print $ solve l
