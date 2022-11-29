-- https://atcoder.jp/contests/abc115/submissions/11031670
l :: (Eq t, Num t, Num a, Num b) => t -> (a, b)
l 0 = (1,1)
l n = (\(a,b) -> (3+a*2,1+2*b)) (l (n-1))
main :: IO ()
main = getLine >>= print . f . map read . words where
  f [n,x]
    | x==0         = 0
    | fst(l n)<x = snd (l n)+1+f [n,x-fst(l n)-1]
    | fst(l n)>x = f [n-1,x-1]
    | otherwise    = snd (l n)
  f _ = error "not come here"
