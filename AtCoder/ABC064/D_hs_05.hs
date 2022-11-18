-- https://atcoder.jp/contests/abc064/submissions/13905608
main :: IO ()
main = interact $ sol . last . lines

sol :: String -> String
sol s = s0 ++ s ++ s1 where
  (b,m) = foldl f (0,0) s
  s0 = replicate (-m) '('
  s1 = replicate (max 0 (b-m)) ')'

f :: (Int,Int) -> Char -> (Int,Int)
f (b,m) '(' = (b+1,m)
f (b,m) _ = (b-1,min m (b-1))
