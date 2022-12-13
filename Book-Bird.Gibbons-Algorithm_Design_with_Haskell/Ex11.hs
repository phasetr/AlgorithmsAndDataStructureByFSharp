module Ex11 where
-- P.281 Exercise11.2, Answer11.2
subseqs :: a -> [[a]]
subseqs = concat . foldr op [[[]]] where
  op :: a -> [[[a]]] -> [[[a]]]
  op x (xss:xsss) = xss:step x xss xsss
  op _ _ = error "undefined"
  step x xss [] = [map (x:) xss]
  step x xss (yss:ysss) = (map (x:) xss++yss):step x yss ysss

-- P.284 Answer 11.5
tstep :: Ord a => a -> [[a]] -> [[a]]
tstep x (xs:xss) = xs:search xs x xss where
  search xs x [] = [x:xs]
  search xs x (ys:xss)
    | head ys >= x = ys:search ys x xss
    | otherwise = (x:xs):xss
tstep _ _ = error "undefined"

-- P.282 Exercise11.6, P.285 Answer 11.6
data Tree a = Null | Node Int (Tree a) a (Tree a)
rmost ::Tree [a] -> [a]
rmost (Node l xs Null) = xs
rmost (Node l xs r) = rmost r
-- P.282 Exercise11.7, P.285 Answer 11.7
lus :: Ord a => [a] -> [a]
lus = rmost . foldr update (Node 1 Null [] Null)
  where update x t = modify x (split x t)
split :: Ord a => a -> Tree [a] -> (Tree [a],Tree [a])
split x t = sew (pieces x t [])
pieces :: Ord a => a -> Tree [a] -> [Piece [a]] -> [Piece [a]]
data Piece a = LP (Tree a) a | RP a (Tree a)

pieces x Null ps = ps
pieces x (Node l xs r) ps
  | null xs || (x<head xs) = pieces x r (LP l xs:ps)
  | otherwise = pieces x l (RP xs r :ps)

-- P.285 Answer 11.8
modify :: a -> (Tree [a],Tree [a]) -> Tree [a]
modify x (t1,t2) = combine t1 (replace (x:rmost t1) t2)
replace::[a] -> Tree [a] -> Tree [a]
replace xs Null = Node 1 Null xs Null
replace xs (Node h Null ys r) = Node h Null xs r
replace xs (Node h l ys r) = Node h (replace xs l) ys r

-- P.285 Answer 11.9
encode xs ys = concatMap (posns ys) xs
posns ys x = reverse [i | (i,y) <- zip [0..] ys,y == x]
decode us ys = pick us (zip [0..] ys) where
  pick [] pys = []
  pick (u:us) ((p,y):pys) = if u == p then y:pick us pys else pick (u:us) pys
decode1 us xs ys = pick us [(posns ys x,x) | x <- xs] where
  pick [] psxs = []
  pick (u:us) ((ps,x):psxs) =
    if u `elem` ps then x:pick us psxs else pick (u:us) psxs

-- P.286 Answer 11.10
help p xs [] = p
help p [] ys = -1
help p (x:xs) (y:ys)
  | x == y    = help (p-1) xs ys
  | otherwise = help (p-1) xs (y:ys)

-- P.286 Answer 11.12
tails = scanr (λx xs.[x]++xs) []
inits = scanl (λxs x.xs++[x]) []

-- P.286 Answer 11.13
--msp b (x:xs) = x:ys++zs

-- P.287 Answer 11.14
-- msp ← MaxWith sum・inits
msp = snd . foldr step (0,[])
step x (s,xs) = if x+s>0 then (x+s,x:xs) else (0,[])
mss = snd . maxWith fst ・scanr step (0,[])
