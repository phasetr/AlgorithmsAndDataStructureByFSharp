module Table (Table(..),newTable,findTable,updTable) where

newTable  :: (Eq b) => [(b,a)] -> Table a b
findTable :: (Eq b) => Table a b -> b -> a
updTable  :: (Eq b) => (b,a) -> Table a b -> Table a b

newtype Table a b = Tbl [(b,a)] deriving (Show,Eq)

newTable = Tbl

findTable (Tbl []) i = error "item not found in table"
findTable (Tbl ((j,v):r)) i
  | i==j      = v
  | otherwise = findTable (Tbl r) i

updTable e (Tbl [])         = Tbl [e]
updTable e'@(i,_) (Tbl (e@(j,_):r))
  | i==j      = Tbl (e':r)
  | otherwise = Tbl (e:r')
  where Tbl r' = updTable e' (Tbl r)
