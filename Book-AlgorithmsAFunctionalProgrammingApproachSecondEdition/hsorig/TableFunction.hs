module TableFunction (Table(..),newTable,findTable,updTable) where

newTable  :: (Eq b) => [(b,a)] -> Table a b
findTable :: (Eq b) => Table a b -> b -> a
updTable  :: (Eq b) => (b,a) -> Table a b -> Table a b

newtype Table a b = Tbl (b -> a)

instance Show (Table a b) where
  showsPrec _ _ str = showString "<<A Table>>" str

newTable = foldr updTable (Tbl (\_ -> error "item not found in table"))

findTable (Tbl f) = f

updTable (i,x) (Tbl f) = Tbl g where
  g j | j==i      = x
      | otherwise = f j
