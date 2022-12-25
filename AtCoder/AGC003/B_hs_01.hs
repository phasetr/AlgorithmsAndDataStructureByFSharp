-- https://atcoder.jp/contests/agc003/submissions/9822723
import Control.Monad ( replicateM )
main :: IO ()
main = do
  n <- readLn
  a <- replicateM n readLn
  print (f (tail a) (head a) 0)
  where
    f [] b i = i+quot b 2
    f [a] b i = i+quot (a+b) 2
    f (x:a) b i = f a (min x (mod (x+b) 2)) (i+quot (x+b) 2)
