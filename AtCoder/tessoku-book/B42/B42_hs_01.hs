-- https://atcoder.jp/contests/tessoku-book/submissions/38658401
import Control.Monad ( replicateM )
import qualified Data.ByteString.Char8 as C
import Data.List ( foldl', unfoldr )

main :: IO ()
main = (readLn >>= flip replicateM get) >>= print . sol
  where get = unfoldr (C.readInt . C.dropWhile (<'+')) <$> C.getLine

(.+.) :: (Num a, Num b) => (a, b) -> (a, b) -> (a, b)
(a,b) .+. (a',b') = (a+a',b+b')
infixl 6 .+.

sol :: [[Int]] -> Int
sol = g . foldl' f ((0,0),(0,0),(0,0),(0,0)) . map (\(a:b:_) -> (a,b)) where
  f (t0,t1,t2,t3) (a,b) = (u0,u1,u2,u3) where
    u0 = if a+b>0 then t0 .+. (a,b) else t0
    u1 = if a-b>0 then t1 .+. (a,-b) else t1
    u2 = if b-a>0 then t2 .+. (-a,b) else t2
    u3 = if a+b<0 then t3 .+. (-a,-b) else t3
  g ((a0,b0),(a1,b1),(a2,b2),(a3,b3)) = maximum [a0+b0,a1+b1,a2+b2,a3+b3]
