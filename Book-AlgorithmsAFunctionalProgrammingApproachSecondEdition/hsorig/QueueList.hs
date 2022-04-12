module QueueList where

emptyQueue :: Queue a
queueEmpty :: Queue a -> Bool
enqueue    :: a -> Queue a -> Queue a
dequeue    :: Queue a -> Queue a
front      :: Queue a -> a

newtype Queue a = Q [a] deriving Show

emptyQueue = Q []

queueEmpty (Q []) = True
queueEmpty (Q _ ) = False

enqueue x (Q q) = Q (q ++ [x])

dequeue (Q (_:xs)) = Q xs
dequeue (Q [])     = error "dequeue: empty queue"

front (Q (x:_)) = x
front (Q [])    = error "front: empty queue"
