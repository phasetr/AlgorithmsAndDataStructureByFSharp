{-# LANGUAGE TupleSections #-}
-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_A/review/3143176/acd1034/Haskell
gt :: (Int,Int) -> (Int,Int) -> Bool
gt (x1,x2) (y1,y2) = x2>y2
inc :: (Int,Int) -> (Int,Int)
inc (x1,x2) = (x1+1,x2)

swap :: [(Int,Int)]->[(Int,Int)]
swap [] = []
swap [x] = [x]
swap (x:xs)
  | gt x y = inc y:x:ys
  | otherwise = x:y:ys
  where (y:ys) = swap xs
bsort :: [(Int,Int)] -> [(Int,Int)]
bsort [] = []
bsort xs = y : bsort ys where (y:ys) = swap xs

pair :: a -> b -> (a,b)
pair x y = (x,y)

main :: IO ()
main = getLine >> getLine >>=
  putStrLn . (\(xs,ys) -> unwords (map show ys) ++ "\n" ++ show (sum xs))
  . unzip
  . bsort
  . map ((0,) . read) . words
--  . map ((\y -> (0,y)) . read) . words
