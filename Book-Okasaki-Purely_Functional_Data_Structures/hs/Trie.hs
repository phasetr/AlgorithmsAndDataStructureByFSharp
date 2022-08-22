{-# LANGUAGE FlexibleInstances #-}
{-# LANGUAGE MultiParamTypeClasses #-}
module Trie (Trie) where
  import Prelude hiding (lookup)
  import FiniteMap ( FiniteMap(..) )
  import Data.Maybe ( fromMaybe )

  data Trie mk ks a = Trie (Maybe a) (mk (Trie mk ks a))

  instance FiniteMap m k => FiniteMap (Trie (m k)) [k] where
    empty = Trie Nothing empty

    lookup [] (Trie b m) = b
    lookup (k : ks) (Trie b m) = lookup k m >>= \m' -> lookup ks m'

    bind [] x (Trie b m) = Trie (Just x) m
    bind (k : ks) x (Trie b m) =
      let
        t = fromMaybe empty (lookup k m)
        -- t = case lookup k m of
        --   Just t -> t
        --   Nothing -> empty
        t' = bind ks x t
      in Trie b (bind k t' m)
