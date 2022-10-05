-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP2_1_A/review/6243797/a143753/Haskell
import Data.Sequence as S
    ( fromList, index, viewr, (|>), Seq, ViewR((:>), EmptyR) )

ans :: Seq Int -> [[Int]] -> [Int]
ans _ [] = []
-- pushBack
ans v ([0,c2]:r) = ans v' r where v' = v |> c2
-- randomAccess
ans v ([1,c2]:r) = r':ans v r where r' = v `index` c2
-- popBack
ans v ([2]:r) = ans v' r where
  v' = case viewr v of
         EmptyR  -> error "Empty queue"
         xs :> x -> xs
ans _ _ = error "not come here"
main :: IO ()

main = do
  _ <- getLine
  c <- getContents
  let i = map (map read . words) $ lines c
      o = ans (S.fromList []) i
  mapM_ print o

-- time limit exceeded
