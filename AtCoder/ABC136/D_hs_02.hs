-- https://atcoder.jp/contests/abc136/submissions/20854997
import Data.List ( foldl' )
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector.Unboxed as V
main :: IO ()
main = putStrLn.unwords.map show.V.toList.solve=<<B.getLine

solve :: B.ByteString -> V.Vector Int
solve s = V.accum(+)(V.replicate(B.length s)0).snd.foldl' f(0,[]).B.group$s

f :: (Int, [(Int, Int)]) -> B.ByteString -> (Int, [(Int, Int)])
f(i,a)t
  |B.head t=='R'=(i+k,(i+k-1,q+r):(i+k,q):a)
  |otherwise=(i+k,(i-1,q):(i,q+r):a)
  where
    k=B.length t
    (q,r)=divMod k 2
