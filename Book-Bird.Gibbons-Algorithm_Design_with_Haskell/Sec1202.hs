module Sec1202 where
import Sec1201 (Partition,Segment,extendl)
-- P.292 12.2 Managing two bank accounts
c :: Int
c = 100 -- global var
-- P.292 12.2 Managing two bank accounts
safe :: Segment Int -> Bool
safe xs = maximum sums <= c+minimum sums
  where sums = scanl (+) 0 xs

{-
P.292
msp :: [Int] -> Partition Int
-}
-- P.292
safeParts :: Foldable t => t Int -> [[Segment Int]]
safeParts = foldr (concatMap . safeExtendl) [[]]
safeExtendl :: Int -> Partition Int -> [[Segment Int]]
safeExtendl x = filter (safe . head) . extendl x

-- P.292
cost :: Foldable t => [t a] -> (Int, Int)
cost p = (length p,length (head p))

-- P.293
add :: Int -> [[Int]] -> [[Int]]
add x [] = [[x]]
add x (s:p) = if safe (x:s) then (x:s):p else [x]:s:p

-- P.293
msp :: [Int] -> Partition Int
msp = foldr add [] where
  add x [] = [[x]]
  add x (s:p) = if safe (x:s) then (x:s):p else [x]:s:p
