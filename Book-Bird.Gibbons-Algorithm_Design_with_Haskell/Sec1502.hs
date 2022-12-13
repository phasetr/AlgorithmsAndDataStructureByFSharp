module Sec1502 where
import Data.Word (Word16)
import Lib (Nat)

-- P.376 15.2 Expressions with a given sum

-- P.376
-- solutions :: Nat -> [Digit] -> [Expr]
-- solutions n = filter (good n . value) . expressions
-- P.376
type Expr = [Term]
type Term = [Factor]
type Factor = [Digit]
type Digit = Nat
expressions :: [Digit] -> [Expr]
expressions = foldr (concatMap . glue) [[]]
glue :: Digit -> Expr -> [Expr]
glue d [] = [[[[d]]]]
glue d ((ds:fs):ts) = [((d :ds):fs):ts,([d]:ds:fs):ts,[[d]]:(ds:fs):ts]
glue _ _ = error "undefined"
-- P.377
valExpr :: Expr -> Nat
valExpr = sum . map valTerm
valTerm :: Term -> Nat
valTerm = product . map valFact
valFact :: Factor -> Nat
valFact = foldl op 0 where op n d = 10*n+d
-- P.377
good :: Nat -> Nat -> Bool
good n v = v == n
-- P.378
type Values = (Nat,Nat,Nat,Nat)
values :: Expr -> Values
values ((ds:fs):ts) = (10 ^ length ds,valFact ds,valTerm fs,valExpr ts)
values _ = error "undefined"

-- P.378
solutions ::Nat -> [Digit] -> [Expr]
solutions n = map fst . filter (good n) . expressions n where
  expressions :: Nat -> [Digit] -> [(Expr,Values)]
  expressions n = foldr (concatMap . glue) [([],undefined)]
    where glue d = filter (ok n) . extend d
  extend d ([],_) = [([[[d]]],(10,d,1,0))]
  extend d ((ds:fs):ts,(p,f,t,e)) =
    [(((d :ds):fs):ts, (10*p,p*d+f,t,e)),
     (([d]:ds:fs):ts,
      (10,d,f*t,e)),
     ([[d]]:(ds:fs):ts,(10,d,1,f*t+e))]
  extend _ _ = error "undefined"
  good n (ex,(p,f,t,e)) = f*t+e == n
  ok n (ex,(p,f,t,e)) = f*t+e <= n
