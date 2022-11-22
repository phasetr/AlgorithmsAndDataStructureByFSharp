-- https://atcoder.jp/contests/abc145/submissions/22940393
import Data.List

main :: IO ()
main = do
  [x,y] <- map read . words <$> getLine
  print $ compute x y

compute :: Int -> Int -> Int
compute x y
  | q /= 0 || a < 0 || b < 0 = 0
  | otherwise = combMod (a+b) a
  where
    (z,q) = divMod (x+y) 3
    (a,b) = (y-z,x-z)

combMod :: Int -> Int -> Int
combMod n r = mul (foldl' mul 1 [r+1..n]) (recipMod (foldl' mul 1 [2..n-r])) where
  modBase = 1000000007
  re a = mod a modBase
  mul a b = re (a * b)
  recipMod a = re $ you $ head $ dropWhile cond $ iterate step (a, modBase, 1, 0) where
    step (a,b,u,v) = let t = a `div` b in  (b, a - t * b, v, u - t * v)
    cond (_,b,_,_) = b /= 0
    you (_,_,u,_) = u
