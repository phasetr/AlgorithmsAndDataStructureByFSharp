-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_B/review/3177391/anndonut/Haskell
import Data.List ( sortOn )

inputList :: (Eq t, Num t) => t -> [a] -> [[a]]
inputList 0 _ = []
inputList n (a:b:c:rest) = [a, b, c] : inputList (n-1) rest
inputList _ _ = error "not come here"

parent :: (Num t, Eq t) => [[t]] -> t -> t
parent [] n = -1
parent ([x, y, z]:xs) n =
  if y == n || z == n then x
  else parent xs n
parent _ _ = error "not come here"

findNode :: (Num t, Eq t) => [[t]] -> t -> [t]
findNode [] n = [-1, -1, -1] -- fxxking node
findNode ([x, y, z]:xs) n
  | x == n = [x, y, z]
  | otherwise = findNode xs n
findNode _ _ = error "not come here"

sibling :: (Eq t, Num t) => [[t]] -> t -> t
sibling xs n = sibling_ xs n (parent xs n)
sibling_ :: (Eq p, Num p) => [[p]] -> p -> p -> p
sibling_ xs n p
  | p == -1 = -1
  | otherwise = sibling__ xs n (findNode xs p)
sibling__ :: Eq p1 => p2 -> p1 -> [p1] -> p1
sibling__ xs n [_, q, r]
  | q == n = r
  | otherwise = q
sibling__ _  _ _ = error "not come here"

degree :: (Eq a, Num p, Num a) => [a] -> p
degree [x, y, z] = zeroOrOne (y /= -1) + zeroOrOne (z /= -1)
  where zeroOrOne bl = if bl then 1 else 0
degree _ = error "not come here"

depth :: (Eq t, Num t, Num p) => [[t]] -> t -> p
depth xs n = depth_ $ parent xs n
  where depth_ p = if p == -1 then 0 else depth xs p + 1

height :: (Num p, Ord p, Num t, Eq t) => [[t]] -> t -> p
height xs (-1) = -1
height xs n = max (height xs y) (height xs z) + 1
    where [_, y, z] = findNode xs n

printType :: (Eq a, Num a) => [[a]] -> [a] -> [Char]
printType xs [x, y, z]
  | parent xs x == -1 = "root"
  | degree [x, y, z] == 0 = "leaf"
  | otherwise = "internal node"
printType _ _ = error "not come here"

printNode :: (Show a, Num a, Eq a) => [[a]] -> [a] -> [Char]
printNode xs node =
  "node " ++ show id ++ ": parent = " ++ show (parent xs id)
  ++ ", sibling = " ++ show (sibling xs id)
  ++ ", degree = " ++ show (degree node)
  ++ ", depth = " ++ show (depth xs id)
  ++ ", height = " ++ show (height xs id)
  ++ ", " ++ printType xs node
  where [id, _, _] = node

main :: IO ()
main = do
  str <- getContents
  let xs1 = map (\x -> read x :: Int) (words str)
  let xs2 = inputList (head xs1) (tail xs1)
  let xs3 = sortOn head xs2
  let res = foldl (\acc x -> acc ++ printNode xs3 x ++ "\n") "" xs3
  putStr res
