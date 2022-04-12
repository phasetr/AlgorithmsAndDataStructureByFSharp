module Queue(Queue,emptyQueue,queueEmpty,enqueue,dequeue,front) where

emptyQueue :: Queue a
queueEmpty :: Queue a -> Bool
enqueue    :: a -> Queue a -> Queue a
dequeue    :: Queue a -> Queue a
front      :: Queue a -> a

newtype Queue a      = Q ([a],[a])
instance (Show a) => Show (Queue a) where
  showsPrec p (Q (front, rear)) str
    = showString "Q " (showList (front ++ reverse rear) str)

queueEmpty (Q ([],[])) = True
queueEmpty _           = False

emptyQueue        = Q ([],[])

enqueue x (Q ([],[])) = Q ([x],[])
enqueue y (Q (xs,ys)) = Q (xs,y:ys)

dequeue (Q ([],[]))   = error "dequeue:empty queue"
dequeue (Q ([],ys))   = Q (tail(reverse ys) , [])
dequeue (Q (x:xs,ys)) = Q (xs,ys)

front (Q ([],[]))   = error "front:empty queue"
front (Q ([],ys))   = last ys
front (Q (x:xs,ys)) = x
