module Stack (Stack(..),push,pop,top,emptyStack,stackEmpty) where

-- | P.87
emptyStack :: Stack a
-- | P.87
stackEmpty :: Stack a -> Bool
-- | P.87
push :: a -> Stack a -> Stack a
-- | P.87
pop :: Stack a -> Stack a
-- | P.87
top :: Stack a -> a

-- | P.88, implementation with a constructor type
data Stack a = EmptyStk | Stk a (Stack a) deriving Eq

instance (Show a) => Show (Stack a) where
  showsPrec p EmptyStk  str = showChar '-' str
  showsPrec p (Stk x s) str = shows x (showChar '|' (shows s str))

-- | P.88
emptyStack = EmptyStk

-- | P.88
stackEmpty EmptyStk = True
stackEmpty _        = False

-- | P.88
push = Stk

-- | P.88
pop EmptyStk  = error "pop from an empty stack"
pop (Stk _ s) = s

-- | P.88
top EmptyStk  = error "top from an empty stack"
top (Stk x _) = x
