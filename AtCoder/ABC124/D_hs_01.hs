-- https://atcoder.jp/contests/abc124/submissions/14394600
import Data.List ( scanl', group )
main :: IO ()
main = do
  [n,k] <- map read . words <$> getLine
  s <- getLine
  let gs = (\x -> if even (length x) then x ++ [0] else x) . (\x -> if head s == '0' then 0:x else x) . map length $ group s
      xs = scanl' (+) 0 gs
      k' = min (2*k+1) (length gs)
      ans = maximum . map snd . filter fst . zip (cycle [True,False]) $ zipWith (-) (drop k' xs) xs
  print ans
