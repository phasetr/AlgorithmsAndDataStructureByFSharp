-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 29 : Non-Deterministic Finite Automata

module Chap29_nondeterministic_finite_automata where
       
import Data.List (nub, intersect)

import Chap26_combinatorial_algorithms (cpair)

-- NFAs in Haskell

type Sym = Char
type Trans q = (q, Sym, q)
data FA q = FA [q] [Sym] [Trans q] [q] [q] deriving Show

isDFA :: Eq q => FA q -> Bool
isDFA (FA qs sigma delta ss fs) =
  length ss == 1
  && and [ or [ (q,x,q') `elem` delta | q' <- qs]
           | q <- qs, x <- sigma ]
  && and [ q' == q'' | (q,x,q') <- delta, q'' <- qs,
                       (q,x,q'') `elem` delta ]

data State = A0 | A1 | A2 | B0 | B1 | B2 deriving (Eq,Show)
qs8' = [A0,A1,A2,B0,B1,B2]
sigma8' = ['a','b']
delta8' = [(A0,'a',A1), (A1,'b',A2), (A2,'a',A2), (A2,'b',A2),
           (B0,'a',B0), (B0,'b',B0), (B0,'a',B1), (B1,'b',B2)]
ss8' = [A0,B0]
fs8' = [A2,B2]

m8' :: FA State
m8' = FA qs8' sigma8' delta8' ss8' fs8'

b8 = isDFA m8'

star :: Eq q => [Trans q] -> q -> [Sym] -> [q]
star delta q "" = [q]
star delta q (x:xs) =
  nub (concat [ star delta q' xs
                | (r,y,q') <- delta, r == q, x == y ])

accept :: Eq q => FA q -> [Sym] -> Bool
accept (FA qs sigma delta ss fs) xs =
  concat [ star delta q xs | q <- ss ] `intersect` fs /= []

bs8' = star delta8' B0 "aba"

b8' = accept m8' "aba"

traces :: Eq q => [Trans q] -> q -> [Sym] -> [[q]]
traces delta q "" = [[q]]
traces delta q (x:xs) =
  nub (concat [ map (q:) (traces delta q' xs)
                | (r,y,q') <- delta, r == q, x == y ])

bss8' = traces delta8' B0 "aba"

productDFA :: (Eq a,Eq b) => FA a -> FA b -> FA (a,b)
productDFA fa@(FA qs sigma delta ss fs)
           fa'@(FA qs' sigma' delta' ss' fs')
  | not (isDFA fa) || not (isDFA fa')
    = error "not DFAs"
  | sigma/=sigma'
    = error "alphabets are different"
  | otherwise
    = FA (cpair qs qs') sigma dd [(q0,q0')] (cpair fs fs')
        where dd    = [ ((q1,q1'), x, (q2,q2'))
                        | (q1,x,q2) <- delta,
                          (q1',x',q2') <- delta', x==x' ]
              [q0]  = ss
              [q0'] = ss'

-- Exercise 5

reverseNFA :: FA q -> FA q
reverseNFA (FA qs sigma delta ss fs) = FA qs sigma undefined fs ss
