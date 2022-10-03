-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_E/review/1616111/cojna/Haskell
{-# LANGUAGE BangPatterns #-}

main :: IO ()
main = getLine >>= putStrLn.unwords.map show.solve.map read.words

solve :: [Int] -> [Int]
solve [a, b] = [x, y] where
  (x, y) = gcdExt a b
solve _ = error "not come here"

gcdExt :: Int -> Int -> (Int, Int)
gcdExt _ 0 = (1, 0)
gcdExt a b = (y, x - q * y) where
  (!q, !r) = quotRem a b
  (!x, !y) = gcdExt b r
