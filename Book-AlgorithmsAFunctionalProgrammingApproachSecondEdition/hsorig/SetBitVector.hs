module SetBitVector (Set,emptySet,setEmpty,inSet,addSet,delSet) where

showSet :: Show a => [a] -> String -> String
showSet []     str = showString "{}" str
showSet (x:xs) str = showChar '{' ( shows x ( showl xs str)) where
  showl []     str = showChar '}' str
  showl (x:xs) str = showChar ',' (shows x (showl xs str))

newtype Set = St Int

emptySet  :: Set
setEmpty  :: Set -> Bool
inSet     :: Int -> Set -> Bool
addSet    :: Int -> Set -> Set
delSet    :: Int -> Set -> Set

instance  Show Set where
  showsPrec _  s str = showSet (set2List s) str

emptySet = St 0

setEmpty (St n) = n==0

inSet i (St s)
  | (i>=0) && (i<=maxSet) = odd (s `div` (2^i))
  | otherwise             = error ("inEnumset:illegal element = " ++ show i)

addSet i (St s)
  | (i>=0) && (i<=maxSet) = St (d'*e+m)
  | otherwise             = error ("insertEnumset:illegal element = " ++ show i)
  where
    (d,m) = divMod s e
    e  = 2^i
    d' = if odd d then d else d+1

delSet i (St s)
  | (i>=0) && (i<=maxSet) = St (d'*e+m)
  | otherwise             = error ("delEnumset:illegal element = " ++ show i)
  where
    (d,m) = divMod s e
    e = 2^i
    d' = if odd d then d-1 else d

set2List :: Num a => Set -> [a]
set2List (St s) = s2l s 0 where
  s2l 0 _             = []
  s2l n i | odd n     = i : s2l (n `div` 2) (i+1)
          | otherwise = s2l (n `div` 2) (i+1)

maxSet :: Int
maxSet = truncate (logBase 2 (fromIntegral (maxBound::Int))) - 1
