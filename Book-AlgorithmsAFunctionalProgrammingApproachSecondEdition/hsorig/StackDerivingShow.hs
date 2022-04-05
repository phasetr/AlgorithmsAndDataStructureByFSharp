module Stack(Stack,push,pop,top,emptyStack,stackEmpty) where

emptyStack:: Stack a
stackEmpty:: Stack a -> Bool
push :: a-> Stack a -> Stack a
pop :: Stack a -> Stack a
top :: Stack a -> a

-- | list implementation
newtype Stack a = Stk [a] deriving Show

emptyStack = Stk []

stackEmpty (Stk []) = True
stackEmpty (Stk _ ) = False

push x (Stk xs) = Stk (x:xs)

pop (Stk [])     = error "pop from an empty stack"
pop (Stk (_:xs)) = Stk  xs

top (Stk [])    = error "top from an empty stack"
top (Stk (x:_)) = x
