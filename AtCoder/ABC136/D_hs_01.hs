-- https://atcoder.jp/contests/abc136/submissions/6797039
import Data.List ( group )
main :: IO ()
main = getLine >>= putStr . unwords . map show . q 0 . group

q :: Foldable t => Int -> [t a] -> [Int]
q _[] = []
q 0(g:s) = q (length g) s
q n(g:s) = replicate (n-1) 0 ++ (a+m-b):(b+n-a): replicate (m-1) 0 ++ q 0 s where
  [a,b] = map (`div` 2) [n+1,m+1]
  m = length g
