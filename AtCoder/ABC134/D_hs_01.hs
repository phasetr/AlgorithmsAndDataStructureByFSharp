-- https://atcoder.jp/contests/abc134/submissions/6473981
import Data.Array ( listArray, (!), assocs )

main :: IO ()
main = do
  li <- getLine
  let n = read li
  li <- getLine
  let as = map read $ words li
  let ans = compute n as
  print (length ans)
  putStrLn $ unwords $ map show ans

compute :: Int -> [Int] -> [Int]
compute n as = [i | (i,1) <- assocs ca] where
  aa = listArray (1,n) as
  ca = listArray (1,n) (map c [1..n])
  c i = (aa ! i + x) `mod` 2
    where x = sum [ ca ! k | k <- [2*i,3*i..n] ]
