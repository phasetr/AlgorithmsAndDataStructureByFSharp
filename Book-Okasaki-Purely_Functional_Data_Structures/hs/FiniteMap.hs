{-# LANGUAGE MultiParamTypeClasses #-}
module FiniteMap (FiniteMap(..)) where
  -- 多引数型クラスが使えることを前提とする！
  class FiniteMap m k where
    empty :: m k a
    bind :: k -> a -> m k a -> m k a
    lookup :: k -> m k a -> Maybe a
