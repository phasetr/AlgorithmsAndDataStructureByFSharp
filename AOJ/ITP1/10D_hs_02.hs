-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_D/review/2213556/aimy/Haskell
main :: IO ()
main = interact
  $ unlines . map show . solve
  . map (map read . words) . tail . lines

solve :: (Ord a, Floating a) => [[a]] -> [a]
solve [vx,vy] = [md 1, md 2, md 3, mdi] where
  md p = sum (zipWith (\x y -> abs (x-y) ** p) vx vy) ** (1/p)
  mdi = maximum (map abs (zipWith subtract vx vy))
solve _ = undefined
