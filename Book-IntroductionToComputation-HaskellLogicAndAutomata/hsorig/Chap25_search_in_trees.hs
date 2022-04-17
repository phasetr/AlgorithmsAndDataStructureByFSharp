-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 25 : Search in Trees

module Chap25_search_in_trees where

-- Trees, again

data Tree a = Nil | Node (Tree a) a (Tree a)
  deriving (Eq,Show)

t :: Tree Int
t = Node (Node (Node Nil 4 Nil)
               2
               (Node Nil 5 Nil))
         1
         (Node (Node (Node Nil 8 Nil)
                     6
                     (Node Nil 9 Nil))
               3                      
               (Node Nil 7 Nil))
inf :: Tree Int
inf = infFrom 0
  where
    infFrom x = Node (infFrom (x-1)) x (infFrom (x+1))

labelsAtDepth :: Int -> Tree a -> [a]
labelsAtDepth d Nil          = []
labelsAtDepth 0 (Node l x r) = [x]
labelsAtDepth n (Node l x r) =
  labelsAtDepth (n-1) l ++ labelsAtDepth (n-1) r

l0 = labelsAtDepth 3 inf

-- Depth-first search

dfTraverse :: Tree a -> [a]
dfTraverse Nil          = []
dfTraverse (Node l x r) = x : (dfTraverse l) ++ (dfTraverse r)

l1 = dfTraverse t

depthFirst :: (a -> Bool) -> Tree a -> Maybe a
depthFirst p t =
  head( [Just x | x <- dfTraverse t, p x] ++ [Nothing] )

n1 = depthFirst (< -4) inf

l2 = dfTraverse inf

-- Breadth-first search

bfTraverse :: Tree a -> [a]
bfTraverse t = bft 0 t
  where
    bft :: Int -> Tree a -> [a]
    bft n t | null xs   = []
            | otherwise = xs ++ bft (n + 1) t
                where xs = labelsAtDepth n t
l3 = bfTraverse t

bfTraverse' :: Tree a -> [a]
bfTraverse' t = bft [t]
  where
    bft :: [Tree a] -> [a]
    bft []                = []
    bft (Nil : ts)        = bft ts
    bft (Node l x r : ts) = x : bft (ts ++ [l,r])

breadthFirst :: (a -> Bool) -> Tree a -> Maybe a
breadthFirst p t =
  head( [Just x | x <- bfTraverse t, p x] ++ [Nothing] )

n0' = breadthFirst (>4) t

n1' = breadthFirst (< -4) inf

n2 = depthFirst (>2) t

n2' = breadthFirst (>2) t

-- runs forever
n3 = depthFirst (>0) inf

n3' = breadthFirst (>0) inf

-- Best-first search

emptyPQ :: (b -> Int) -> PQ b
insertPQ :: b -> PQ b -> PQ b
topPQ :: PQ b -> b
popPQ :: PQ b -> PQ b
isemptyPQ :: PQ b -> Bool

-- see Exercise 1
data PQ a = Undefined
emptyPQ = undefined
insertPQ = undefined
topPQ = undefined
popPQ = undefined
isemptyPQ = undefined

bestFirstTraverse :: (Tree a -> Int) -> Tree a -> [a]
bestFirstTraverse f t = bft (insertPQ t (emptyPQ f))
  where
    bft :: PQ (Tree a) -> [a]
    bft pq | isemptyPQ pq = []
           | otherwise    = x : bft (insertPQ' r (insertPQ' l pq'))
                where Node l x r = topPQ pq
                      pq'        = popPQ pq

insertPQ' :: Tree a -> PQ (Tree a) -> PQ (Tree a)
insertPQ' Nil pq = pq
insertPQ' t pq   = insertPQ t pq

bestFirst :: (a -> Bool) -> (Tree a -> Int) -> Tree a -> Maybe a
bestFirst p f t =
  head( [Just x | x <- bestFirstTraverse f t, p x] ++ [Nothing] )

eval :: Tree Int -> Int
eval Nil = 0
eval (Node l x r) = x

n4 = bestFirst (>19) eval inf

n4' = breadthFirst (>19) inf

n5 = bestFirst (>100) eval inf
