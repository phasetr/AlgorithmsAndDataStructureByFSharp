-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_B/review/1697757/satoshi3/Haskell
import Data.List ( isInfixOf )
main :: IO ()
main = getContents >>=
  mapM_ print . (\(x:_:xs) -> map (h x) xs) . map (map read . words) . lines
  where
    h [a,b,c,d,e,f] x
      | i x s = a+0
      | i x t = b
      | i x u = c
      | i x (r u) = d
      | i x (r t) = e
      | i x (r s) = f
      where  i = isInfixOf
             r = reverse
             s = [b,c,e,d,b]
             t = [a,d,f,c,a]
             u = [a,b,f,e,a]
    h _ _ = undefined
