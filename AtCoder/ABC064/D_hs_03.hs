-- https://atcoder.jp/contests/abc064/submissions/13906080
main :: IO ()
main = interact $ sol . last . lines

sol :: String -> String
sol s = replicate (m-b) '(' ++ s ++ replicate m ')'
  where (b,m) = foldr f (0,0) s

f :: (Num a, Ord a) => Char -> (a, a) -> (a, a)
f '(' (b,m) = (b+1,max m (b+1))
f ')' (b,m) = (b-1,m)
f _ _ = error "not come here"
