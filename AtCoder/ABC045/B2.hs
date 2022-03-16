{-
https://atcoder.jp/contests/abc045/submissions/30160642
-}
main :: IO ()
main = do
  a <- getLine
  b <- getLine
  c <- getLine
  putStrLn $ solve a b c

solve :: String -> String -> String -> String
solve = fa where
    fa "" _ _ = "A"
    fa (a:as) bs cs = f a as bs cs

    fb _ "" _ = "B"
    fb as (b:bs) cs = f b as bs cs

    fc _ _ "" = "C"
    fc as bs (c:cs) = f c as bs cs

    f 'a' = fa
    f 'b' = fb
    f 'c' = fc
    f _ = error "not come here"
