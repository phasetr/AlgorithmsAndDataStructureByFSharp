-- https://atcoder.jp/contests/tessoku-book/submissions/35370695
import Control.Monad ( foldM )

main :: IO Integer
main = do
  n <- readLn
  foldM (\n _ -> do
    (t:_:as) <- getLine
    let a = read as
    let n1 = mod (f t n a) 10000
    print n1
    return n1
    ) 0 [1..n]

f :: Num a => Char -> a -> a -> a
f '+' = (+)
f '-' = (-)
f _ = (*)
