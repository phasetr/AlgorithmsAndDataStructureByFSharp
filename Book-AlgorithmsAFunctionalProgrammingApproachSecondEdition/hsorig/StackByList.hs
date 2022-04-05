module StackByList (Stack,push,pop,top,emptyStack,stackEmpty) where

-- | P.88
newtype Stack a = Stk [a] deriving Eq

instance (Show a) => Show (Stack a) where
  showsPrec p (Stk [])     str = showChar '-' str
  showsPrec p (Stk (x:xs)) str
    = shows x (showChar '|' (shows (Stk xs) str))

-- | P.88
emptyStack :: Stack a
emptyStack = Stk []

-- | P.88
stackEmpty :: Stack a -> Bool
stackEmpty (Stk []) = True
stackEmpty (Stk _ ) = False

-- | P.88
push :: a -> Stack a -> Stack a
push x (Stk xs) = Stk (x:xs)

-- | P.88
pop :: Stack a -> Stack a
pop (Stk [])     = error "pop from an empty stack"
pop (Stk (_:xs)) = Stk xs

-- | P.88
top :: Stack p -> p
top (Stk [])    = error "top from an empty stack"
top (Stk (x:_)) = x

main :: IO ()
main = print $ push 3 (push 2 (push 1 emptyStack)) == Stk [3,2,1]
