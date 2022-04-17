-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 22 : Efficient CNF Conversion

module Chap22_efficient_CNF_conversion where

import Data.List (nub)

-- Implication and bi-implication

type Name = String
data Prop = Var Name
          | F
          | T
          | Not Prop
          | Prop :||: Prop
          | Prop :&&: Prop
          | Prop :->: Prop
          | Prop :<->: Prop
  deriving Eq

instance Show Prop where
  show (Var x)    = x
  show F          = "F"
  show T          = "T"
  show (Not p)    = par ("not " ++ show p)
  show (p :||: q) = par (show p ++ " || " ++ show q)
  show (p :&&: q) = par (show p ++ " && " ++ show q)

par :: String -> String
par s = "(" ++ s ++ ")"

type Valn = Name -> Bool

evalProp :: Valn -> Prop -> Bool
evalProp vn (Var x)    = vn x
evalProp vn F          = False
evalProp vn T          = True
evalProp vn (Not p)    = not (evalProp vn p)
evalProp vn (p :||: q) = evalProp vn p || evalProp vn q
evalProp vn (p :&&: q) = evalProp vn p && evalProp vn q
evalProp vn (p :->: q)  = not (evalProp vn p) || evalProp vn q
evalProp vn (p :<->: q) = evalProp vn p == evalProp vn q

type Names = [Name]

names :: Prop -> Names
names (Var x)     = [x]
names F           = []
names T           = []
names (Not p)     = names p
names (p :||: q)  = nub (names p ++ names q)
names (p :&&: q)  = nub (names p ++ names q)
names (p :->: q)  = nub (names p ++ names q)
names (p :<->: q) = nub (names p ++ names q)


