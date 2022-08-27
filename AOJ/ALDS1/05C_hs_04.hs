-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_C/review/1927611/tiqwab_ch90/Haskell
import Control.Monad ( (<=<) )

type Point = (Double, Double)
type Line = (Point, Point)

koch :: Line -> [Line]
koch ((sx, sy), (ex, ey)) = [(p0, p1), (p1, p2), (p2, p3), (p3, p4)] where
  dx = ex - sx
  dy = ey - sy
  pre2 = rotate60 (fst p3 - fst p1, snd p3 - snd p1)
  p0 = (sx, sy)
  p1 = (sx + dx / 3, sy + dy / 3)
  p2 = (fst p1 + fst pre2, snd p1 + snd pre2)
  p3 = (sx + dx * 2 / 3, sy + dy * 2 / 3)
  p4 = (ex, ey)

rotate60 :: Point -> Point
rotate60 (x, y) = (x / 2 - y * sqrt 3 / 2 , x * sqrt 3 / 2 + y / 2)

main :: IO ()
main = do
  n <- readLn
  let result =
        case n of
          0 -> [((0, 0), (100, 0))]
          _ -> foldr1 (<=<) (replicate n koch) ((0, 0), (100, 0))
  mapM_ (putStrLn . \((sx, sy), _) -> show sx ++ " " ++ show sy) result
  putStrLn $ (\(x, y) -> show x ++ " " ++ show y) . snd . last $ result
