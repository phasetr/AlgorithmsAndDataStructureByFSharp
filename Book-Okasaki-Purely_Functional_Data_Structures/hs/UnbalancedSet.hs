{-# LANGUAGE FlexibleInstances #-}
{-# LANGUAGE MultiParamTypeClasses #-}
module UnbalancedSet (UnbalancedSet) where
  import Set

  data UnbalancedSet a = E | T (UnbalancedSet a) a (UnbalancedSet a)

  instance Ord a => Set UnbalancedSet a where
    empty = E

    member x E = False
    member x (T a y b)
      | x < y = member x a
      | x > y = member x b
      | otherwise = True

    insert x E = T E x E
    insert x s@(T a y b)
      | x < y = T (insert x a) y b
      | x > y = T a y (insert x b)
      | otherwise = s
