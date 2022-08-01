-- https://onlinejudge.u-aizu.ac.jp/problems/ITP1_11_B
import Data.List ( isInfixOf )
main :: IO ()
main = do
  s <- fmap ((\[a,b,c,d,e,f] -> (a,b,c,d,e,f)) . map read . words) getLine
  getLine
  qs <- fmap (map (map read . words) . lines) getContents
  mapM_ print $ solve s qs

solve :: (Num b, Eq b) => (b, b, b, b, b, b) -> [[b]] -> [b]
solve s = map (help s) where
  help (a,b,c,d,e,f) q
    | i q s = a+0
    | i q t = b
    | i q u = c
    | i q (r u) = d
    | i q (r t) = e
    | otherwise = f
    where
      i = isInfixOf
      r = reverse
      s = [b,c,e,d,b]
      t = [a,d,f,c,a]
      u = [a,b,f,e,a]

test :: IO ()
test = print $ solve (1,2,3,4,5,6) [[6,5],[1,3],[3,2]] == [3,5,6]
