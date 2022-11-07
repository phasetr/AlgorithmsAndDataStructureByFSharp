-- https://atcoder.jp/contests/abc084/submissions/9848309
main :: IO ()
main = do
  n <- readLn
  csf <- map (map read . words) . lines <$> getContents
  putStr $ unlines $ [show $ solve 0 $ drop i csf | i <- [0..n-1]]

solve :: Integral t => t -> [[t]] -> t
solve now [] = now
solve now ([c,s,f]:csf) = solve (c + max s((now+f-1) `div` f * f)) csf
solve _ _ = error "not come here"
