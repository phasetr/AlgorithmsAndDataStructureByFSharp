-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_C/review/2192980/a143753/Haskell
import Data.List ( minimumBy )
import Text.Printf ( printf )

rd :: String -> (Char,Int)
rd (c:n) = (c,read n)
rd _ = undefined
sh :: (Char,Int) -> String
sh (c,n) = printf "%c%d" c n

cmp :: Ord a1 => (a2, a1) -> (a3, a1) -> Ordering
cmp (_,n1) (_,n2) = compare n1 n2
gt :: Ord a1 => (a2, a1) -> (a3, a1) -> Bool
gt (_,n1) (_,n2) = n1 > n2
lt :: Ord a1 => (a2, a1) -> (a3, a1) -> Bool
lt (_,n1) (_,n2) = n1 < n2

-- bubble sort
bubbleIter :: (Num b, Ord a1) => [(a2, a1)] -> (Bool, b, [(a2, a1)])
bubbleIter []     = (False,0,[])
bubbleIter [x] = (False,0,[x])
bubbleIter (x0:x1:xs) =
  let (f,n,x) = if x0 `gt` x1
                then bubbleIter (x0:xs)
                else bubbleIter (x1:xs)
  in
    if x0 `gt` x1
    then (True,n+1,x1:x)
    else (f,   n  ,x0:x)
bubbleSort :: (Num a1, Ord a2) => a1 -> [(a3, a2)] -> (a1, [(a3, a2)])
bubbleSort n x =
  let (f,n',x') = bubbleIter x
  in
    if f
    then bubbleSort (n'+n) x'
    else (n'+n,x')

selectSort :: (Ord a1, Eq a2) => [(a2, a1)] -> [(a2, a1)]
selectSort [] = []
selectSort [x] = [x]
selectSort xs@[x0,x1] = if x1 `lt` x0 then [x1,x0] else xs
selectSort (x0:xs) =
  let m = minimumBy cmp xs
      h = takeWhile (/= m) xs
      t = tail $ dropWhile (/= m) xs
  in
    if m `lt` x0
    then m:selectSort (h ++ [x0] ++ t)
    else x0:selectSort xs

main :: IO ()
main = do
  n <- getLine
  c <- getLine
  let i = words c
      o = map rd i
      (_,b) = bubbleSort 0 o
      s = selectSort o
  putStrLn $ unwords $ map sh b
  putStrLn "Stable"
  putStrLn $ unwords $ map sh s
  let r = if b == s
          then "Stable"
          else "Not stable"
  putStrLn r
