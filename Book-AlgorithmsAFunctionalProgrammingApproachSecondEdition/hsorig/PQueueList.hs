module PQueueList where

-- | P.92, 5.4.1 List implementation
emptyPQ :: (Ord a) => PQueue a
pqEmpty :: (Ord a) => PQueue a -> Bool
enPQ    :: (Ord a) => a -> PQueue a -> PQueue a
dePQ    :: (Ord a) => PQueue a -> PQueue a
frontPQ :: (Ord a) => PQueue a -> a

-- | P.107
newtype PQueue a = PQ[a] deriving Show

emptyPQ = PQ []

pqEmpty (PQ []) = True
pqEmpty _       = False

enPQ x (PQ q) = PQ (insert x q) where
  insert x []                   = [x]
  insert x r@(e:r') | x < e     = x:r
                    | otherwise = e:insert x r'

dePQ (PQ [])     = error "dePQ:empty priority queue"
dePQ (PQ (x:xs)) = PQ xs

frontPQ (PQ [])    = error "frontPQ:empty priority queue"
frontPQ (PQ(x:xs)) = x
