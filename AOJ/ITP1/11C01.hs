-- https://onlinejudge.u-aizu.ac.jp/problems/ITP1_11_C
main :: IO ()
main = do
  dice1 <- fmap ((\[a,b,c,d,e,f] -> (a,b,c,d,e,f)) . map read . words) getLine
  dice2 <- fmap ((\[a,b,c,d,e,f] -> (a,b,c,d,e,f)) . map read . words) getLine
  putStrLn $ solve dice1 dice2

solve :: (Ord a, Num a) => (a, a, a, d1, e1, f1) -> (a, a, a, d2, e2, f2) -> String
solve dice1 dice2 = if b then "Yes" else "No" where
  b = rot dice1 == rot dice2
  rot (a,b,c,d,e,f) = bs++as
    where
      xs = [a,b,c]
      cnt = length $ filter (>= 4) xs
      newdice = map (\x -> min x (7-x)) $ if even cnt then xs else [a,c,b]
      (as,bs) = break (== 1) newdice

test :: IO ()
test = print $ solve (1,2,3,4,5,6) (6,5,4,3,2,1) == "No"
