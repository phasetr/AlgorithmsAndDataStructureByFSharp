-- https://atcoder.jp/contests/agc034/submissions/14162598
main :: IO ()
main = do
  s <- getLine
  print $ solve 0 0 s

solve :: (Num a, Eq a) => a -> a -> [Char] -> a
solve k _ [] = k
solve k a ('A':cs) = solve k (a+1) cs
solve k 0 ('B':'C':cs) = solve k 0 cs
solve k a ('B':'C':cs) = solve (k+a) a cs
solve k a (_:cs) = solve k 0 cs
