module SetUnOrderedListWithDuplicates (Set,emptySet,setEmpty,inSet,addSet,delSet) where

showSet :: Show a => [a] -> String -> String
showSet []     str = showString "{}" str
showSet (x:xs) str = showChar '{' ( shows x ( showl xs str)) where
  showl []     str = showChar '}' str
  showl (x:xs) str = showChar ',' (shows x (showl xs str))

newtype Set a = St [a]

emptySet  :: Set a
setEmpty  :: Set a -> Bool

instance (Show a) => Show (Set a) where
  showsPrec _ (St s) str = showSet s str

emptySet = St []

setEmpty (St []) = True
setEmpty _       = False

inSet     :: (Eq a) => a -> Set a -> Bool
addSet    :: (Eq a) => a -> Set a -> Set a
delSet    :: (Eq a) => a -> Set a -> Set a

inSet x (St xs) = x `elem` xs
addSet x (St a) = St (x:a)
delSet x (St xs) = St (filter (/= x) xs)
