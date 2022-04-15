module Search where
import Data.Array ( Ix, Array, (!), (//), array, elems )
import Graph ( adjacent, nodes, Graph )
import Queue ( dequeue, emptyQueue, enqueue, front, queueEmpty )
import PQueue ( dePQ, emptyPQ, enPQ, frontPQ, pqEmpty )
import Set ( Set, emptySet, inSet, addSet )
import Sort ( qsort )
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

-- P.159 8.2 Backtracking search

-- Section 8.2.1
-- | P.160
type Position  = (Int,Int)
-- | P.160
type Board     = Array Int Position
-- | P.161
newtype Boards = BDS [Board] deriving Eq

g8T :: Board
g8T = array (0,8) [(0,(2,2)),(1,(1,3)),(2,(2,3)),(3,(3,3)),(4,(3,2)),(5,(3,1)),(6,(2,1)),(7,(1,1)),(8,(1,2))]
s8T :: Board
s8T = array (0,8) [(0,(2,2)),(1,(1,1)),(2,(1,3)),(3,(3,3)),(4,(3,2)),(5,(1,2)),(6,(2,3)),(7,(2,1)),(8,(3,1))]

-- | P.160
mandist :: Position -> Position -> Int
mandist (x1,y1) (x2,y2) = abs (x1-x2) + abs (y1-y2)
-- | P.160
allMoves :: Board -> [Board]
allMoves b = [b//[(0,b!i),(i,b!0)] | i <- [1..8], mandist (b!0) (b!i) == 1]
-- | P.161
succ8Tile :: Boards -> [Boards]
succ8Tile (BDS n@(b:bs)) = filter (notIn bs) [BDS(b':n) | b' <- allMoves b] where
  notIn bs (BDS(b:_)) = elems b `notElem` map elems bs
  notIn _ _ = undefined
succ8Tile _ = undefined

-- Section 8.2.2
-- | P.162
searchDfs :: (Eq node) => (node -> [node]) -> (node -> Bool) -> node -> [node]
searchDfs succ goal x = search' (push x emptyStack) where
  search' s
    | stackEmpty s = []
    | goal (top s) = top s : search' (pop s)
    | otherwise    = let x = top s
                     in search' (foldr push (pop s) (succ x))

-- Section 8.2.3
-- | P.163 8.2.3
goal8Tile :: Boards -> Bool
goal8Tile (BDS (n:_)) = elems n == elems g8T
goal8Tile _ = undefined
-- | P.163
dfs8Tile  :: [[Position]]
dfs8Tile  = map elems ls where
  ((BDS ls):_) = searchDfs succ8Tile goal8Tile (BDS [s8T])

-- Section 8.2.4
-- | P.163
type Column     = Int
type Row        = Int
type SolNQ      = [(Column,Row)]

type NodeNQ     = (Column,Column,SolNQ)

-- | P.164
valid :: SolNQ -> (Column,Row) -> Bool
valid psol (c,r)   = all test psol where
  test (c',r') = c'+r'/=c+r && c'-r'/=c-r && r'/=r
-- | P.164
succNq :: NodeNQ -> [NodeNQ]
succNq (c,n,psol)
    = [(c+1,n,psol++[(c,r)]) | r<-[1..n] , valid psol (c,r)]
-- | P.164
goalNq :: NodeNQ -> Bool
goalNq (c,n,psol) = c > n
-- | P.164
firstNq   :: Column -> SolNQ
firstNq n = s where
  ((_,_,s):_) = searchDfs succNq goalNq (1,n,[])
-- | P.164
countNq   :: Column -> Int
countNq n = length (searchDfs succNq goalNq (1,n,[]))

-- Section 8.2.5 The knapsack problem
-- | P.165
type Weight         = Int
type Value          = Float
type Object         = (Weight,Value)
type SolKnp         = [Object]
type NodeKnp        = (Value,Weight,Weight,[Object],SolKnp)

-- | P.165
succKnp :: NodeKnp -> [NodeKnp]
succKnp (v,w,limit,objects,psol) =
  [(v+v',w+w',limit,[o | o@(w'',_) <- objects, w''>=w'],(w',v'):psol)
  | (w',v') <- objects , w+w' <= limit]
-- | P.165
goalKnp :: (Ord a1, Num a1) => (a2, a1, a1, [(a1, b)], e) -> Bool
goalKnp (_,w,limit,(w',_):_,_) = w+w'>limit
goalKnp _ = undefined

-- | P.165
knapsack :: [Object] -> Weight -> (SolKnp,Value)
knapsack objects limit = (sol,v) where
  (v,_,_,_,sol) = maximum (searchDfs succKnp goalKnp (0,0,limit,qsort objects,[]))

-- P.167 8.3 Priority-first search
-- | P.168 8.3.1 The priority-first search higher-order function
searchPfs :: (Ord node) => (node -> [node]) -> (node -> Bool) -> node -> [(node,Int)]
searchPfs succ goal x = search' (enPQ x emptyPQ) 0 where
  search' q  t
    | pqEmpty q        = []
    | goal (frontPQ q) = (frontPQ q, t+1) : search' (dePQ q) (t+1)
    | otherwise        = let x = frontPQ q
                         in search' (foldr enPQ (dePQ q) (succ x)) (t+1)

