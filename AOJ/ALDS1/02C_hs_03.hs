-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_C/review/2012211/earlgrey/Haskell
import Data.List ( delete )

suit :: String -> Char
suit = head

rank :: String -> Int
rank s = read $ drop 1 s

swap :: [String] -> Int -> Int -> [String]
swap xs i j = take i xs ++ [xs!!j] ++ take (j-i-1) (drop (i+1) xs) ++ [xs !! i] ++ drop (j+1) xs

bubble :: Int -> [String] -> [String]
bubble n xs = foldl (\ys i -> if rank (ys !! i) < rank (ys !! (i - 1)) then swap ys (i - 1) i else ys) xs [j | i <- [0 .. n - 1], j <- [n - 1, n - 2 .. i + 1]]

selection :: Int -> [String] -> [String]
selection n xs = foldl (\ys i -> let m = f ys i in if i == m then ys else swap ys i m) xs [0 .. n - 1]
    where f ys i = foldl (\j k -> if rank (ys !! k) < rank (ys !! j) then k else j) i [i + 1 .. n - 1]

remove :: [String] -> Int -> [String]
remove xs i = take i xs ++ drop (i + 1) xs

stable :: [String] -> [String] -> String
stable [] []     = "Stable"
stable os (x:xs) = if pred os x then stable (delete x os) xs else "Not stable" where
  pred [] _     = False
  pred (y:ys) x = if rank x == rank y then suit x == suit y else pred ys x
stable _ _ = undefined

main :: IO ()
main = do
  n  <- readLn
  os <- fmap words getLine
  let bs = bubble n os
  let ss = selection n os
  putStr $ unlines [unwords bs, stable os bs, unwords ss, stable os ss]
