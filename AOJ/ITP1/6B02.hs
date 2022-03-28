-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_6_B/review/3483265/yachiwataru/Haskell
main = getLine >> getContents >>=
  mapM_ putStrLn
  . (\cards -> filter (\x -> notElem x $ lines cards)
               [x ++ " " ++ show y | x <- ["S","H","C","D"], y <- [1..13]])
