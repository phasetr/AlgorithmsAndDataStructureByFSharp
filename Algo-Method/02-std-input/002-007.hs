{-
https://algo-method.com/tasks/31
2 つの文字列 S,T が改行区切りで入力されます。S と T が等しい文字列であるかを判定してください。
-}
import Data.Bool (bool)
import Control.Monad (replicateM)
main :: IO ()
main = getContents >>= putStr
  . (\[s,t] -> if s==t then "Yes" else "No")
  . lines

test1 = bool "No" "Yes" . (\[s,t] -> s==t) . lines
test2 = replicateM 2 getLine >>=
  putStr . (\[s,t] -> if s==t then "Yes" else "No")
