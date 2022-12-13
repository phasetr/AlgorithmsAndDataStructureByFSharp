module Lib where
type Nat = Int

-- P.010
inserts :: a -> [a] -> [[a]]
inserts x [] = [[x]]
inserts x (y:ys) = (x:y:ys):map (y:) (inserts x ys)
perms :: [a] -> [[a]]
perms = foldr (concatMap . inserts) [[]]
-- P.011
picks :: [a] -> [(a,[a])]
picks [] = []
picks (x:xs) = (x,xs) : [(y,x:ys) | (y,ys) <- picks xs]

-- P.017 Exercise 1.3
wrap :: a -> [a]
wrap x = [x]

unwrap :: [a] -> a
unwrap [x] = x
unwrap _ = error "unwrap: Not a single element"

single :: [a] -> Bool
single [x] = True
single _ = False

-- Question1.13
apply :: Nat -> (a -> a) -> a -> a
apply n f = if n==0 then id else f . apply (n-1) f

-- P.33 Section2.3
-- Data.List
inits :: [a] -> [[a]]
inits [] = [[]]
inits (x:xs) = []:map (x:) (inits xs)

-- Data.List
tails :: [a] -> [[a]]
tails [] = [[]]
tails (x:xs) = (x:xs):tails xs

-- P.59 Answer2.14
tailsl :: [a] -> [[a]]
tailsl = takeWhile (not . null) . iterate tail

-- P.140, 6.1
pairWith :: (t -> t -> t) -> [t] -> [t]
pairWith f [ ] = [ ]
pairWith f [x] = [x]
pairWith f (x:y:xs) = f x y:pairWith f xs

-- P.145
minWith :: Ord b => (a -> b) -> [a] -> a
minWith f = foldr1 (smaller f) where
  smaller f x y = if f x <= f y then x else y

-- P.180
foldrn :: (a -> b -> b)-> (a -> b) -> [a] -> b
foldrn f g [] = error "foldrn: empty list"
foldrn f g [x] = g x
foldrn f g (x:xs) = f x (foldrn f g xs)

-- P.218
maxInt :: Int
maxInt = maxBound
