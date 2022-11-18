-- https://atcoder.jp/contests/abc064/submissions/15847559
import Control.Arrow ( Arrow((&&&)) )
main :: IO ()
main = putStrLn . solve =<< (getLine >> getLine)

solve :: String -> String
solve s = replicate (b-a) '(' ++ s ++ replicate b ')'
  where (a,b) = (head &&& maximum) . scanr f 0 $ s
f :: Num a => Char -> a -> a
f '(' i=i+1
f _ i=i-1
