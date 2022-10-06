-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP2_1_B/review/6248553/a143753/Haskell
import Data.Sequence as S
    ( (<|),
      fromList,
      index,
      viewl,
      viewr,
      (|>),
      Seq,
      ViewL((:<), EmptyL),
      ViewR((:>), EmptyR) )

ans :: Seq Int -> [[Int]] -> [Int]
ans _ [] = []
ans v ([0,d,x]:r) = ans v' r where -- pushBack
  v' = case d of
         1 -> v |> x
         0 -> x <| v
         _ -> error "not come here"

ans v ([1,p]:r) = r':ans v r where -- randomAccess
  r' = v `index` p

ans v ([2,d]:r) = ans v' r where -- popBack
  v' = case d of
         1 -> case viewr v of
                EmptyR  -> error "Empty queue"
                xs :> x -> xs
         0 -> case viewl v of
                EmptyL  -> error "Empty queue"
                x :< xs -> xs
         _ -> error "not come here"
ans _ _ = error "not come here"

main :: IO ()
main = do
  _ <- getLine
  c <- getContents
  let i = map (map read . words) $ lines c :: [[Int]]
      o = ans (S.fromList []) i
  mapM_ print o
