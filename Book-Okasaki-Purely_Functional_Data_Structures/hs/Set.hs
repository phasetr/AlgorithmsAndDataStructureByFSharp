{-# LANGUAGE MultiParamTypeClasses #-}
module Set (Set(..)) where
  -- 多引数型クラスが使えることを前提とする！
  class Set s a where
    empty :: s a
    insert :: a -> s a -> s a
    member :: a -> s a -> Bool
