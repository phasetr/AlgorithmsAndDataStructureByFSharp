-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_A/review/1696901/amusan39/Haskell
solve :: [a] -> [Char] -> [a]
solve d [] = d
solve [a,b,c,d,e,f] (x:xs)
  | x == 'E' = solve [d,b,a,f,e,c] xs
  | x == 'N' = solve [b,f,c,d,a,e] xs
  | x == 'S' = solve [e,a,c,d,f,b] xs
  | x == 'W' = solve [c,b,f,a,e,d] xs
solve _ _ = undefined

main :: IO ()
main = do
  dice <- fmap words getLine
  com <- getLine
  putStrLn $ (!! 0) $ solve dice com
