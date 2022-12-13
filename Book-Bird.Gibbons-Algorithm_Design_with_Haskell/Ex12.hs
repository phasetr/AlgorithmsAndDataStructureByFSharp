module Ex12 where
import Lib (minWith)
import Sec1201 (Partition,bind,cons,glue,snoc)
import Sec1202 (safe)
import Sec1203 (Para,Text,cost1,fits)
-- P.300 Exercise12.3
parts :: [a] -> [Partition a]
parts = foldr step [[]] where
  step x [[]] = [[[x]]]
  step x ps = map (cons x) ps++map (glue x) ps

-- P.300 Exercise 12.5, P.304 Answer12.5
leftmin :: Ord a => [a] -> Bool
leftmin xs = all (head xs <=) xs
rightmax :: Ord a => [a] -> Bool
rightmax xs = all (<= last xs) xs
ordered :: Ord a => [a] -> Bool
ordered xs = and (zipWith (<=) xs (tail xs))
nomatch :: (Eq a, Num a, Enum a) => [a] -> Bool
nomatch xs = and (zipWith (/=) xs [0..])

-- P.301 Exercise12.9, P.304 Answer12.9
msp :: [Int] -> Partition Int
msp = part . foldr add ([],0,0) where
  c = 10 -- constant
  part (p,n,m) = p
  add x pnm | null (part pnm) = cons x pnm
            | safe (glue x pnm) = glue x pnm
            | otherwise = cons x pnm
  cons x (p,n,m) = ([x]:p,min 0 x,max 0 x)
  glue x (s:p,n,m) = ((x:s):p,min 0 (x+n),max 0 (x+m))
  glue _ _ = error "undefined"
  safe (p,n,m) = max 0 (-n) <= min c (c-m)

-- P.301 Exercise12.10, P.305 Answer12.10
endpoints :: [Int] -> (Int,Int)
endpoints xs = if n<0 then (-n,x-n) else (0,x) where
  n = minimum sums
  x = last sums
  sums = scanl (+) 0 xs
-- map endpoints [[40,?85,55],[?32,79],[80],[?21,80]] == [(45,55),(32,79),(0,80),(21,80)]
transfers :: Partition Int -> [Int]
transfers = collect . map endpoints
collect ::[(Int,Int)] -> [Int]
collect xys = zipWith (-) (map fst xys++[0]) (0:map snd xys)
-- collect [(45,55),(32,79),(0,80),(21,80)] == [45,?23,?79,?59,?80]

-- P.301 Exercise12.12, P.306 Answer12.12
msp2 :: [Int] -> Partition Int
msp2 = foldl add [] where
  add [] x = [[x]]
  add p x = head (filter (safe . last) [bind x p,snoc x p])

-- P.301 Exercise12.13, P.306 Answer12.13
runs :: Ord a => [a] -> Partition a
runs = foldr add [] where
  add x [] = [[x]]
  add x (s:p) = if ordered (x:s) then (x:s):p else [x]:s:p

-- P.302 Exercise12.16, P.307 Answer12.16
greedy :: Foldable t => [t a] -> [[t a]]
greedy (w:ws) = help ((w:),length w) ws where
  maxWidth = 10 -- constant
  help (f,d1) [] = [f []]
  help (f,d1) (w:ws)
    | d2 <= maxWidth = help (f . (w:),d2) ws
    | otherwise = f []:help ((w:),d) ws
    where d2 = d1 +1+d; d = length w
greedy _ = error "undefined"

-- P.302 Exercise12.21, P.307 Answer12.21
para :: Text -> Para
para = minWith cost . foldr tstep [[]] where
  cost = cost1 -- 適当に選んだだけ
  maxWidth = 16 -- constant
  optWidth = 16 -- constant
  tstep w [[]] = [[[w]]]
  tstep w ps = cons w (minWith cost ps):
    filter (fits . head) (map (glue w) ps)

-- P.303 Exercise12.22, P.308 Answer12.22
para2 :: Text -> Para
para2 = thePara . minWith cost . thinparts where
  maxWidth = 10 -- parameter
  optWidth = 10 -- parameter
  thePara (p,_,_) = reverse (map reverse p)
  cost (_,c,_) = c
  ok (_,_,k) = k <= maxWidth
  thinparts (w:ws) = foldl step (start w) ws
  thinparts _ = error "undefined"
  start w = [([[w]],0,length w)]
  step ps w = minWith cost (map (snoc w) ps):
    takeWhile ok (map (bind w) ps)
  snoc w (p,c,k) = (cons w p,c+(optWidth-k)^2,length w)
  bind w (p,c,k) = (glue w p, c, k+1+length w)
