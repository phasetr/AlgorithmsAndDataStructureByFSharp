-- https://atcoder.jp/contests/tenka1-2019/submissions/9944101
main :: IO ()
main = do
 getLine
 s <- getLine
 let l = scanl (+) 0 $ map (\c -> if c=='#' then 1 else 0) s
 let r = scanr (+) 0 $ map (\c -> if c=='#' then 0 else 1) s
 print $ minimum $ zipWith (+) l r
