-- https://atcoder.jp/contests/tessoku-book/submissions/37630015
import Data.Bool ( bool )
import qualified Data.ByteString.Char8 as C
import Data.Vector.Generic ((!))
import qualified Data.Vector.Unboxed as U

main :: IO ()
main = sol <$> readLn <*> get >>= print

get :: IO [Char]
get = C.unpack <$> C.getLine

sol :: Int -> String -> Int
sol 1 _ = 1
sol n s = (! 0) . snd $ dp where
  v = U.fromListN n s
  u0 = U.replicate n 1
  u1 = U.generate (n-1) (\i -> bool 1 2 $ v!i==v!(i+1))
  dp = U.foldl' f (u0,u1) (U.enumFromN 2 (n-2))
  f (w0,w1) i = (w1,w2) where
    w2 = U.zipWith max t0 t1
    t0 = U.generate (n-i) (\j -> w0!(j+1)+bool 0 2 (v!j==v!(j+i)))
    t1 = U.zipWith max w1 $ U.tail w1
