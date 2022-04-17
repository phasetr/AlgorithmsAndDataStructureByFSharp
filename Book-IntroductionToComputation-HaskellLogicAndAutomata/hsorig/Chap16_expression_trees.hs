-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 16 : Expression Trees

module Chap16_expression_trees where

import Data.List (nub)

import Test.QuickCheck (Arbitrary, arbitrary, sized, oneof)
import Control.Monad (liftM, liftM2)

-- Arithmetic expressions

data Exp = Lit Int
         | Add Exp Exp
         | Mul Exp Exp
  deriving Eq

e0 = Add (Lit 1) (Mul (Lit 2) (Lit 3))
e1 = Mul (Add (Lit 1) (Lit 2)) (Lit 3)
e2 = Add e0 (Mul (Lit 4) e1)

showExp :: Exp -> String
showExp (Lit n)   = show n
showExp (Add e f) = par (showExp e ++ " + " ++ showExp f)
showExp (Mul e f) = par (showExp e ++ " * " ++ showExp f)

par :: String -> String
par s = "(" ++ s ++ ")"

instance Show Exp where
  show e = showExp e

-- Evaluating arithmetic expressions

evalExp :: Exp -> Int
evalExp (Lit n)   = n
evalExp (Add e f) = evalExp e + evalExp f
evalExp (Mul e f) = evalExp e * evalExp f

i0 = evalExp e0

i1 = evalExp e1

i2 = evalExp e2

-- Arithmetic expressions with infix constructors

data Exp' = Lit' Int
          | Exp' `ADD` Exp'
          | Exp' `MUL` Exp'
  deriving Eq

e0' = Lit' 1 `ADD` (Lit' 2 `MUL` Lit' 3)
e1' = (Lit' 1 `ADD` Lit' 2) `MUL` Lit' 3
e2' = e0' `ADD` ((Lit' 4) `MUL` e1')

instance Show Exp' where
  show (Lit' n)     = show n
  show (e `ADD` f) = par (show e ++ " + " ++ show f)
  show (e `MUL` f) = par (show e ++ " * " ++ show f)

evalExp' :: Exp' -> Int
evalExp' (Lit' n)     = n
evalExp' (e `ADD` f) = evalExp' e + evalExp' f
evalExp' (e `MUL` f) = evalExp' e * evalExp' f

data Exp'' = Lit'' Int
         | Exp'' :+: Exp''
         | Exp'' :*: Exp''
  deriving Eq

e0'' = Lit'' 1 :+: (Lit'' 2 :*: Lit'' 3)
e1'' = (Lit'' 1 :+: Lit'' 2) :*: Lit'' 3
e2'' = e0'' :+: ((Lit'' 4) :*: e1'')

instance Show Exp'' where
  show (Lit'' n)   = show n
  show (e :+: f) = par (show e ++ " + " ++ show f)
  show (e :*: f) = par (show e ++ " * " ++ show f)

evalExp'' :: Exp'' -> Int
evalExp'' (Lit'' n)   = n
evalExp'' (e :+: f) = evalExp'' e + evalExp'' f
evalExp'' (e :*: f) = evalExp'' e * evalExp'' f

-- Propositions

type Name = String
data Prop = Var Name
          | F
          | T
          | Not Prop
          | Prop :||: Prop
          | Prop :&&: Prop
  deriving Eq

p0 = Var "a" :&&: Not (Var "a")
p1 = (Var "a" :&&: Var "b")
     :||: (Not (Var "a") :&&: Not (Var "b"))
p2 = (Var "a" :&&: Not (Var "b")
              :&&: (Var "c" :||: (Var "d" :&&: Var "b"))
         :||: (Not (Var "b") :&&: Not (Var "a")))
     :&&: Var "c"

instance Show Prop where
  show (Var x)    = x
  show F          = "F"
  show T          = "T"
  show (Not p)    = par ("not " ++ show p)
  show (p :||: q) = par (show p ++ " || " ++ show q)
  show (p :&&: q) = par (show p ++ " && " ++ show q)

-- Evaluating propositions

type Valn = Name -> Bool

evalProp :: Valn -> Prop -> Bool
evalProp vn (Var x)    = vn x
evalProp vn F          = False
evalProp vn T          = True
evalProp vn (Not p)    = not (evalProp vn p)
evalProp vn (p :||: q) = evalProp vn p || evalProp vn q
evalProp vn (p :&&: q) = evalProp vn p && evalProp vn q

valn :: Valn
valn "a" = True
valn "b" = True
valn "c" = False
valn "d" = True

b0 = evalProp valn p0

b1 = evalProp valn p1

b2 = evalProp valn p2

-- Satisfiability of propositions

type Names = [Name]

names :: Prop -> Names
names (Var x)    = [x]
names F          = []
names T          = []
names (Not p)    = names p
names (p :||: q) = nub (names p ++ names q)
names (p :&&: q) = nub (names p ++ names q)

n0 = names p0

n1 = names p1

n2 = names p2

empty :: Valn
empty y = error "undefined"

extend :: Valn -> Name -> Bool -> Valn
extend vn x b y | x == y    = b
                | otherwise = vn y

valns :: Names -> [Valn]
valns [] = [ empty ]
valns (x:xs)
         = [ extend vn x b | vn <- valns xs, b <- [True, False] ]

satisfiable :: Prop -> Bool
satisfiable p = or [ evalProp vn p | vn <- valns (names p) ]

bs0 = [ evalProp vn p0 | vn <- valns (names p0) ]

bss0 = satisfiable p0

bs1 = [ evalProp vn p1 | vn <- valns (names p1) ]

bss1 = satisfiable p1

bs2 = [ evalProp vn p2 | vn <- valns (names p2) ]

bss2 = satisfiable p2

-- Structural induction

simplify :: Exp -> Exp
simplify (Lit n)     = Lit n
simplify (e `Add` f)
  | e' == Lit 0      = f'
  | f' == Lit 0      = e'
  | otherwise        = e' `Add` f'
  where e' = simplify e
        f' = simplify f
simplify (e `Mul` f) = (simplify e) `Mul` (simplify f)

-- Mutual recursion

data Exp''' = Lit''' Int
            | Add''' Exp''' Exp'''
            | Mul''' Exp''' Exp'''
            | If Cond Exp''' Exp'''
  deriving Eq
  
data Cond = Eq Exp''' Exp'''
          | Lt Exp''' Exp'''
          | Gt Exp''' Exp'''
  deriving Eq

me0 = Add''' (Lit''' 1) (Mul''' (Lit''' 2) (Lit''' 3))
me1 = Mul''' (Add''' (Lit''' 1) (Lit''' 2)) (Lit''' 3)
mc0 = Lt me0 me1
me2 = If mc0 me0 me1

instance Show Exp''' where
  show (Lit''' n)   = show n
  show (Add''' e f) = par (show e ++ " + " ++ show f)
  show (Mul''' e f) = par (show e ++ " * " ++ show f)
  show (If c e f)   = "if " ++ show c
                            ++ " then " ++ show e
                            ++ " else " ++ show f

instance Show Cond where
  show (Eq e f) = show e ++ " == " ++ show f
  show (Lt e f) = show e ++ " < " ++ show f
  show (Gt e f) = show e ++ " > " ++ show f

evalExp''' :: Exp''' -> Int
evalExp''' (Lit''' n)   = n
evalExp''' (Add''' e f) = evalExp''' e + evalExp''' f
evalExp''' (Mul''' e f) = evalExp''' e * evalExp''' f
evalExp''' (If c e f)   = if evalCond c then evalExp''' e
                          else evalExp''' f
                     
evalCond:: Cond -> Bool
evalCond (Eq e f) = evalExp''' e == evalExp''' f
evalCond (Lt e f) = evalExp''' e < evalExp''' f
evalCond (Gt e f) = evalExp''' e > evalExp''' f

i0''' = evalExp''' me0

i1''' = evalExp''' me1

b0''' = evalCond mc0

i2''' = evalExp''' me2

-- Exercise 5

instance Arbitrary Prop where
  arbitrary = sized prop
    where
      prop n | n<=0 = oneof [liftM Var arbitrary,
                             return T,
                             return F]
             | otherwise
                    = oneof [liftM Not subprop,
                             liftM2 (:||:) subprop subprop,
                             liftM2 (:&&:) subprop subprop]
        where subprop = prop (n `div` 2)
