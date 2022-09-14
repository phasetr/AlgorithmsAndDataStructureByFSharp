-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_A/review/2107518/Yoshimura/Haskell
import Control.Monad ( when, forM_, replicateM )
import Data.Array ( Array, listArray, (!), (//) )

main :: IO ()
main = do
  n <- readLn
  grp <- fmap (map (drop 2 . map read . words)) (replicateM n getLine)
  let arr = listArray ((0,0),(n-1,n-1)) $ repeat 0
      adj = trans grp 0 arr
  forM_ [0..n-1] $ \i -> do
    forM_ [0..n-1] $ \j -> do
      when (j>0) $ putChar ' '
      putStr $ show $ adj ! (i,j)
    putStrLn ""

trans :: [[Int]] -> Int -> Array (Int, Int) Int -> Array (Int, Int) Int
trans [] _ adj = adj
trans (x:xs) i adj = trans xs (i+1) (adj // upd) where
  upd = foldl (\acc v -> ((i,v-1), 1):acc) [] x
