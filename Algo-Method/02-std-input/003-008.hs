{-
https://algo-method.com/tasks/59
N 個の文字列 S0,S1,…,SN−1が与えられます。
N 個の文字列を前からすべてつなげてできる文字列の長さを出力してください。
-}
import Control.Monad (replicateM)
main :: IO ()
main = do
  n <- readLn
  xs <- replicateM n getLine
  (print . length . concat) xs

-- https://algo-method.com/submissions/353495
solve1 :: IO ()
solve1 = (getLine >>= (`replicateM` getLine) . read)
  >>= print . length . concat
