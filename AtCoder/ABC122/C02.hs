-- https://atcoder.jp/contests/abc122/submissions/13416421
import Data.List
import Data.Maybe
import qualified Data.ByteString.Char8 as B
import qualified Data.Vector as V
main :: IO ()
main = putStr . f . g . B.lines =<< B.getContents

ris :: B.ByteString -> [Int]
ris = map (fst . fromJust . B.readInt) . B.words

g :: [B.ByteString] -> ([Int], B.ByteString, [[Int]])
g (nq:s:lrs) = (ris nq, s,map ris lrs)
g _ = error "undefined"

f :: ([a], B.ByteString, [[Int]]) -> String
f ([n,q], s, lrs) = unlines
  $ map(\[l,r] -> show $ vs V.!r - vs V.!l) lrs where
  vs = V.fromList
    $ scanl'(+) 0
    $ 0:B.zipWith (\x y->if x=='A' && y=='C' then 1 else 0) s (B.tail s)
f _ = error "undefined"
