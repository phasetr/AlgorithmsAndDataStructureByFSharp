-- https://atcoder.jp/contests/apc001/submissions/10334375
main = do
 getLine
 a <- map read . words <$> getLine
 b <- map read . words <$> getLine
 let u = zipWith (-) b a
 let s = sum u
 putStrLn $ if s < negate (sum $ filter (<0) u ) || s < sum (map (flip div 2 . (1+)) $ filter (>0) u) then "No" else "Yes"
