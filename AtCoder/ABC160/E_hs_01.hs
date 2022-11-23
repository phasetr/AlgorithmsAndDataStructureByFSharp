-- https://atcoder.jp/contests/abc160/submissions/15731034
import Data.List ( sort )
main :: IO ()
main = do
 [x,y,a,b,c] <- map read . words <$> getLine
 p <- sort . map read . words <$> getLine
 q <- sort . map read . words <$> getLine
 r <- map read . words <$> getLine
 print $ sum $ drop c $ sort $ drop (a-x) p ++ drop (b-y) q ++ r
