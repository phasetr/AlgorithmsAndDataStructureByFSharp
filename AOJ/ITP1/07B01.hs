-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_7_B
import Control.Applicative ((<$>))
main :: IO ()
main = do
  [n,x] <- map read . words <$> getLine
  if (n,x)==(0,0) then return () else do
    print $ solve n x
    main

solve :: Int -> Int -> Int
solve n x = length
  [(i,j,k) |
    i <- [1..n-2]
    , j <- [i+1..n-1]
    , k <- [j+1..n]
    , i+j+k==x]

{-
test = solve 5 9 == 2
-}
