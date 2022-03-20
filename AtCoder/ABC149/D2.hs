{-
https://atcoder.jp/contests/abc149/submissions/23138373
-}
import Data.List (transpose)

cut :: [a] -> Int -> [[a]]
cut [] k = []
cut t k = take k t:cut (drop k t) k

score :: Num p => Char -> p -> p -> p -> p
score t r s p
    | t == 'r' = p
    | t == 's' = r
    | t == 'p' = s
    | otherwise = 0

f :: Num t => t -> t -> t -> [Char] -> t
f r s p [] = 0
f r s p [t]  = score t r s p
f r s p (t:ts) = score t r s p  + f r s p ts' where
  t' = head ts
  ts' = if t == t' then tail ts else ts

main :: IO ()
main = do
  [n,k] <- map read . words <$> getLine :: IO [Int]
  [r,s,p] <- map read . words <$> getLine :: IO [Int]
  t <- getLine
  print $ sum $ map (f r s p) $ transpose $ cut t k
