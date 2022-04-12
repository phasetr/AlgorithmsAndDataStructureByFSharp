-- SetOrderdedWithoutDuplicates
module Set (Set,emptySet,setEmpty,inSet,addSet,delSet) where

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

inSet  :: (Ord a) => a -> Set a -> Bool
addSet :: (Ord a) => a -> Set a -> Set a
delSet :: (Ord a) => a -> Set a -> Set a

inSet x (St s) = x `elem` takeWhile (<= x) s

addSet x (St s) = St (add x s) where
  add x []                   = [x]
  add x s@(y:ys)
    | x>y       = y : add x ys
    | x<y       = x : s
    | otherwise = s

delSet x (St s) = St (del x s) where
  del x []                   = []
  del x s@(y:ys)
    | x>y       = y : del x ys
    | x<y       = s
    | otherwise = ys
