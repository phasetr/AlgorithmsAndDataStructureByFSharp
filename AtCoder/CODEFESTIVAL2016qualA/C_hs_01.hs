-- https://atcoder.jp/contests/code-festival-2016-quala/submissions/10969776
import Data.Array ( Array, array, (!) )
alp :: Array Char Int
alp = array ('a','z') (zip ['a'..'z'] (0:[25,24..1]))
main :: IO ()
main = do
 s <- getLine; k <- readLn
 putStrLn(f s k)
  where
    f [c] k = [([c..'z']++['a'..'z']) !! mod k 26]
    f (c:s) k = if (alp!c)<=k then 'a':f s (k-(alp!c)) else c:f s k
    f _ _ = error "not come here"
