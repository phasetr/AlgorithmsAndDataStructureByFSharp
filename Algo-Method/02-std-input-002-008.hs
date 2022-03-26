{-
https://algo-method.com/tasks/26
3 つの文字列 S, T, U が改行区切りで入力されます。U と T と S をこの順につなげた文字列を出力してください。
-}
import Control.Monad (replicateM)
main :: IO ()
main = getContents >>= putStr . concat . reverse . lines

solve1 = replicateM 3 getLine >>= putStr . concat . reverse
