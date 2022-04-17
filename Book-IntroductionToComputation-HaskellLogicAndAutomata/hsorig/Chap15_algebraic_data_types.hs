-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 15 : Algebraic Data Types

module Chap15_algebraic_data_types where

import Test.QuickCheck (Arbitrary, arbitrary, sized, oneof)
import Control.Monad (liftM2)

-- Booleans

-- The following type definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (Bool, True, False)

-- data Bool = False | True

eqBool :: Bool -> Bool -> Bool
eqBool False False = True
eqBool True  True  = True
eqBool _     _     = False

showBool :: Bool -> String
showBool False = "False"
showBool True  = "True"

-- Seasons

data Season = Winter | Spring | Summer | Fall

next :: Season -> Season
next Winter = Spring
next Spring = Summer
next Summer = Fall
next Fall   = Winter

eqSeason :: Season -> Season -> Bool
eqSeason Winter Winter = True
eqSeason Spring Spring = True
eqSeason Summer Summer = True
eqSeason Fall   Fall   = True
eqSeason _      _      = False

showSeason :: Season -> String
showSeason Winter = "Winter"
showSeason Spring = "Spring"
showSeason Summer = "Summer"
showSeason Fall   = "Fall"

data Season' = Winter' | Spring' | Summer' | Fall' deriving (Eq,Show)

toInt :: Season -> Int
toInt Winter = 0
toInt Spring = 1
toInt Summer = 2
toInt Fall   = 3

fromInt :: Int -> Season
fromInt 0 = Winter
fromInt 1 = Spring
fromInt 2 = Summer
fromInt 3 = Fall

next' :: Season -> Season
next' x = fromInt ((toInt x + 1) `mod` 4)

eqSeason' :: Season -> Season -> Bool
eqSeason' x y = (toInt x == toInt y)

-- Shapes

type Radius = Float
type Width  = Float
type Height = Float

data Shape = Circle Radius
           | Rect Width Height
  deriving (Eq,Show)

area :: Shape -> Float
area (Circle r) = pi * r^2
area (Rect w h) = w * h

eqShape :: Shape -> Shape -> Bool
eqShape (Circle r) (Circle r')  = (r == r')
eqShape (Rect w h) (Rect w' h') = (w == w') && (h == h')
eqShape _          _            = False

showShape :: Shape -> String
showShape (Circle r) = "Circle " ++ showF r
showShape (Rect w h) = "Rect " ++ showF w ++ " " ++ showF h

showF :: Float -> String
showF x | x >= 0    = show x
        | otherwise = "(" ++ show x ++ ")"

isCircle :: Shape -> Bool
isCircle (Circle r) = True
isCircle (Rect w h) = False

isRect :: Shape -> Bool
isRect (Circle r) = False
isRect (Rect w h) = True

radius :: Shape -> Float
radius (Circle r) = r

width :: Shape -> Float
width (Rect w h) = w

height :: Shape -> Float
height (Rect w h) = h

area' :: Shape -> Float
area' s =
  if isCircle s then
    let
      r = radius s
    in
      pi * r^2
  else if isRect s then
    let
      w = width s
      h = height s
    in
      w * h
  else error "impossible"

-- Tuples

data Pair a b = Pair a b deriving (Eq,Show)

data Pair' a b = MkPair a b deriving (Eq,Show)

eqPair :: (Eq a, Eq b) => Pair a b -> Pair a b -> Bool
eqPair (Pair x y) (Pair x' y') = x == x' && y == y'

showPair :: (Show a, Show b) => Pair a b -> String
showPair (Pair x y) = "Pair " ++ show x ++ " " ++ show y

data Triple a b c = Triple a b c deriving (Eq,Show)

-- Lists

data List a = Nil
            | Cons a (List a)
  deriving (Eq,Show)

append :: List a -> List a -> List a
append Nil ys         = ys
append (Cons x xs) ys = Cons x (append xs ys)

-- Optional values

-- The following type definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (Maybe, Nothing, Just)

-- data Maybe a = Nothing | Just a
--   deriving (Eq,Show)

myDiv :: Int -> Int -> Maybe Int
myDiv n 0 = Nothing
myDiv n m = Just (n `div` m)

i1 = 3 `myDiv` 0

i2 = 6 `myDiv` 2

-- The following function definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (lookup)

-- lookup :: Eq a => a -> [(a,b)] -> Maybe b
-- lookup key []                      = Nothing
-- lookup key ((x,y):xys) | key == x  = Just y
--                        | otherwise = lookup key xys

power :: Maybe Int -> Int -> Int
power Nothing n  = 2 ^ n
power (Just m) n = m ^ n

i3 = power Nothing 3

i4 = power (Just 3) 3

right :: Int -> Int -> Int
right n m = case n `myDiv` m of
              Nothing -> 3
              Just r  -> r + 3

-- Disjoint union of two types

-- The following type definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (Either, Left, Right)

-- data Either a b = Left a | Right b
--   deriving (Eq,Show)

mylist :: [Either Int String]
mylist = [Left 4, Left 1, Right "hello", Left 2,
          Right " ", Right "world", Left 17]

addints :: [Either Int String] -> Int
addints xs = sum [ n | Left n <- xs ]

addstrs :: [Either Int String] -> String
addstrs xs = concat [ s | Right s <- xs ]

l1 = addints mylist

l2 = addstrs mylist

-- Exercise 1

data Fruit = Apple String Bool
           | Orange String Int
  deriving (Eq,Show)

-- Exercise 3

data Widelist a = Nil'
                | Cons' a (Widelist a)
                | Append (Widelist a) (Widelist a)
  deriving (Eq,Show)

instance Arbitrary a => Arbitrary (Widelist a) where
  arbitrary = sized list
    where
      list n | n<=0 = return Nil'
             | otherwise
                    = oneof [liftM2 Cons' arbitrary sublist,
                             liftM2 Append sublist sublist]
        where sublist = list (n `div` 2)

-- Exercise 6

type Password = String
type Locked a = Password -> Maybe a
