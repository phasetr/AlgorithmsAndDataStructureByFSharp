-- https://atcoder.jp/contests/abc054/submissions/4497524
import Control.Monad ( replicateM )
g :: Eq a => [[a]] -> [[a]] -> Int -> Int -> Bool
g a b l r
  | r+length b > length a = False
  | l+length b > length a = g a b 0 (r+1)
  | b==f a l r (length b) = True
  | otherwise = g a b (l+1) r
  where f s p n m = ((take m . drop n) . map (take m . drop p)) s
main :: IO ()
main = do
 [n,m] <- map read.words<$>getLine
 a <- replicateM n getLine
 b <- replicateM m getLine
 putStrLn $ if g a b 0 0 then"Yes"else"No"
