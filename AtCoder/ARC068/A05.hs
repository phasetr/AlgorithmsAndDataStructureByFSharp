-- https://atcoder.jp/contests/arc068/submissions/1081945
main :: IO ()
main = readLn >>= print . f . flip divMod 11 . pred
f :: (Ord a1, Num a1, Num a2) => (a2, a1) -> a2
f (q,r)
  | r<=5 = 2*q+1
  | 0<1 = 2*q+2
  | otherwise = error "undefined"
