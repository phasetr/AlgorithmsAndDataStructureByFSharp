-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_6_C/review/2206980/aimy/Haskell
main = interact
  $ unlines . show' . officialHouse
  . read' . tail . lines
 where
  read' = map ((\[b,f,r,v] -> ((b-1)*30 + (f-1)*10 + r, v)) . map read . words)
  show' = insertAt 3 "####################" . map (unwords.("":)) . groupAt 10 . map (show . snd)
  officialHouse = foldr move [(n,0)| n<-[1..120]]
    where move (c,v) = foldr (\(n,p) acc -> if n==c then (n,p+v):acc else (n,p):acc) []
  groupAt n xs =
    if null xs then []
    else take n xs : groupAt n (drop n xs)
  insertAt n is xs =
    if length xs <= n then xs
    else take n xs ++ [is] ++ insertAt n is (drop n xs)
