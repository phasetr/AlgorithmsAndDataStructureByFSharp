-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_7_A
import Control.Applicative ((<$>))
main :: IO ()
main = do
  [m,f,r] <- map read . words <$> getLine
  if (m,f,r) == (-1,-1,-1) then return () else do
    putStrLn $ solve m f r
    main

solve :: Int -> Int -> Int -> String
solve m f r = case m+f of
  s | m == -1 || f == -1 -> "F"
    | 80 <= s -> "A"
    | 65 <= s -> "B"
    | 50 <= s -> "C"
    | 30 <= s -> if 50 <= r then "C" else "D"
    | otherwise -> "F"
