{-
https://atcoder.jp/contests/agc039/submissions/15726204
-}
import Control.Arrow (Arrow((&&&)))
import Data.Maybe (fromJust)
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector.Unboxed as V
main :: IO ()
main = print . solve . B.lines =<< B.getContents

solve :: [B.ByteString] -> Int
solve [s,ks] = V.sum (V.map ((`div`2) . snd) vs) * k + f ((V.head &&& V.last) vs) where
  k = fst . fromJust . B.readInt $ ks
  vs = V.fromList $ map (B.head &&& B.length) . B.group $s
  f ((c1,k1),(c2,k2))
    | c1 /= c2 || even k1 || even k2 = 0
    | V.length vs == 1=k`div`2
    | otherwise = k-1
solve _ = error "undefined"
