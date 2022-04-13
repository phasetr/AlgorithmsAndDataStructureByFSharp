-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_C/review/6017697/naosak1006/Haskell
main = interact $
  (++"\n") . unwords . map (show . sum)
  . (\y -> [map fst y,map snd y])
  . (\x -> zip x (map g x)) . map f
  . tail . map words . lines
f :: (Ord a, Num p) => [a] -> p
f [a,b] |a>b = 3
        |a==b = 1
        |0<1 = 0
f _ = undefined

g :: (Eq a, Num a, Num p) => a -> p
g a | a==3 =0
    | a==1 = 1
    | otherwise = 3
