-- https://atcoder.jp/contests/abc045/submissions/16276641
import Control.Monad ( foldM )
main :: IO ()
main = getLine >>=
  (\(x:y) -> print $ sum $ concat $ foldM (\[a,t] c -> [[a+t,c],[a,10*t+c]]) [0,x] y)
  . map (read . pure)
