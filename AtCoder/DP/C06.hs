-- https://atcoder.jp/contests/dp/submissions/9832576
import qualified Data.ByteString.Char8 as C
import Data.List (unfoldr)

main = do
  n <- readLn
  (a,b,c) <- loop n (0,0,0)
  print $ max a (max b c)

loop 0 (a,b,c) = return (a,b,c)
loop n (a,b,c) = do
  [a',b',c'] <- unfoldr (C.readInt . C.dropWhile (==' ')) <$> C.getLine
  loop (n-1) (max b c + a', max a c + b', max a b + c')
