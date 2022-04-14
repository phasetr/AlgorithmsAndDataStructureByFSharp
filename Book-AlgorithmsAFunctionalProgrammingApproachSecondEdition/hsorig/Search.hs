module Search where
import Data.Array ( Array, Ix )
import Graph ( adjacent, nodes, Graph )
import Queue ( dequeue, emptyQueue, enqueue, front, queueEmpty )
import Set ( Set, emptySet, inSet, addSet )
import Stack ( emptyStack, pop, push, stackEmpty, top )

-- P.140, 7.3 Depth-first and breadth-first search

-- | P.143
depthFirstSearch :: (Ix a, Num b, Eq b) => a -> Graph a b -> [a]
depthFirstSearch start g = reverse (dfs (push start emptyStack) []) where
  dfs s vis
    | stackEmpty s     = vis
    | top s `elem` vis = dfs (pop s) vis
    | otherwise        =
        let c = top s in dfs (foldr push (pop s) (adjacent g c)) (c:vis)

-- | P.143 ,7.3.2 Breadth-first search
breadthFirstSearch :: (Ix a, Num b, Eq b) => a -> Graph a b -> [a]
breadthFirstSearch start g = reverse (bfs (enqueue start emptyQueue) []) where
  bfs q vis
    | queueEmpty q       = vis
    | front q `elem` vis = bfs (dequeue q) vis
    | otherwise          =
        let c = front q
        in bfs (foldr enqueue (dequeue q) (adjacent g c)) (c:vis)

-- P.149, 7.6 Depth-first search trees and forests
-- P.150, 7.6.1 Extending the basi approach

-- | P.150
data Tree n = NodeGT n [Tree n] deriving (Show,Eq)

-- | P.150
depthFirstTree :: (Eq w,Num w,Ix n) => n -> Graph n w -> Tree n
depthFirstTree s g = head (snd (dfst g (emptySet,[]) s))

-- | P.151
dfst :: (Eq n,Ix n,Eq w,Num w) => Graph n w -> (Set n , [Tree n]) -> n -> (Set n , [Tree n])
dfst g (vs,ts) n
  | inSet n vs  = (vs,ts)
  | otherwise   = (vs', NodeGT n ts' : ts)
  where (vs',ts') = foldl (dfst g) (addSet n vs, []) (adjacent g n)

-- | P.151
dfsforest :: (Eq w,Num w,Ix n) => Graph n w -> [Tree n]
dfsforest g = snd (foldl (dfst g) (emptySet,[]) (nodes g))

-- P.151 7.6.2 Lazy depth-first search

-- | P.152
generate :: (Ix a, Num w, Eq w) => Array (a, a) (Maybe w) -> a -> Tree a
generate g v = NodeGT v (map (generate g) (adjacent g v))

-- | P.152
prune :: Ix n => [Tree n] -> [Tree n]
prune ts = snd (prune' emptySet ts) where
  prune' m [] = (m,[])
  prune' m ((NodeGT v ts):us)
    | inSet v m  = prune' m us
    | otherwise  = let (m',as)  = prune' (addSet v m) ts
                       (m'',bs) = prune' m' us
                    in (m'', NodeGT v as : bs)

-- | P.152
kldfsforest :: (Ix n, Num w, Eq w) => Array (n, n) (Maybe w) -> [Tree n]
kldfsforest g = prune (map (generate g) (nodes g))

-- | P.152
preorderT :: Tree a -> [a]
preorderT (NodeGT v l)= v : concatMap preorderT l

-- | P.152
kldfs :: (Ix a, Num w, Eq w) => a -> Array (a, a) (Maybe w) -> [a]
kldfs v g = preorderT (head (prune (map (generate g) [v])))
