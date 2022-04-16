module Dynamic(module Table,dynamic) where
import Data.Array ( Ix(range) )
import Table

dynamic :: Ix c => (Table entry c -> c -> entry) -> (c,c) -> Table entry c
dynamic compute bnds = t where
  t = newTable (map (\coord -> (coord, compute t coord)) (range bnds))
