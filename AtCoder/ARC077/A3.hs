{-
https://atcoder.jp/contests/abc066/submissions/15248001
-}
main :: IO ()
main = interact $ unwords . map show . solve . map read . words

solve :: [Int] -> [Int]
solve (n:as)
  | even n    = es ++ reverse os
  | otherwise = os ++ reverse es
  where
    (i,es,os) = foldl f (0,[],[]) as
solve _ = undefined

f :: (Int,[Int],[Int]) -> Int -> (Int,[Int],[Int])
f (i,es,os) a
  | even i    = (i+1,es,a:os)
  | otherwise = (i+1,a:es,os)
