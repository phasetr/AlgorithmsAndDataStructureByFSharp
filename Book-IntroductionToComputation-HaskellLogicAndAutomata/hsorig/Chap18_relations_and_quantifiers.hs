-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 18 : Relations and Quantifiers

module Chap18_relations_and_quantifiers where

import Chap06_features_and_predicates (Thing (R, S, T, U, V, W, X, Y, Z), things, Predicate, isDisc, isTriangle, isWhite, isBlack, isGrey, isBig, isSmall)

import Chap14_sequent_calculus (neg, (&:&), (|:|))

-- Expressing logical statements

discsThatArentBlackAreEitherBigOrNotWhite =
  and [ (isBig |:| neg isWhite) x | x <- things, (isDisc &:& neg isBlack) x ]

-- Quantifiers

every :: [u] -> Predicate u -> Bool
every xs p = and [ p x | x <- xs ]

some :: [u] -> Predicate u -> Bool
some xs p = or [ p x | x <- xs ]

everyWhiteTriangleIsSmall = every (filter (isWhite &:& isTriangle) things) isSmall

everyDiscThatIsntBlackIsEitherBigOrNotWhite =
  every (filter (isDisc &:& neg isBlack) things)
        (isBig |:| neg isWhite)

someBigTriangleIsGrey = some (filter (isBig &:& isTriangle) things) isGrey

-- Relations

isBigger :: Thing -> Thing -> Bool
isBigger x y = isBig x && isSmall y


isAbove :: Thing -> Thing -> Bool
isAbove R _ = False
isAbove S x = x `elem` [R,U,V,X,Y]
isAbove T x = x `elem` [R,U,X,Y]
isAbove U x = x `elem` [R,X,Y]
isAbove V x = x `elem` [R,X,Y]
isAbove W x = x `elem` [R,X,Y]
isAbove X x = False
isAbove Y x = False
isAbove Z x = x `elem` [R,X,Y]

type Relation u = u -> u -> Bool

sIsAboveEveryBlackTriangle = every (filter (isBlack &:& isTriangle) things) (S `isAbove`)

everyWhiteDiscIsAboveX = every (filter (isWhite &:& isDisc) things) (`isAbove` X)

blackTriangles :: [Thing]
blackTriangles = filter (isBlack &:& isTriangle) things
greyDiscs :: [Thing]
greyDiscs = filter (isGrey &:& isDisc) things

everyBlackTriangleIsAboveEveryGreyDisc = every blackTriangles (\x -> every greyDiscs (x `isAbove`))

isAboveEveryGreyDisc :: Predicate Thing
isAboveEveryGreyDisc x = every greyDiscs (x `isAbove`)

everyBlackTriangleIsAboveEveryGreyDisc' = every blackTriangles isAboveEveryGreyDisc

bigBlackTriangles :: [Thing]
bigBlackTriangles =
  filter (isBig &:& isBlack &:& isTriangle) things

everyBigBlackTriangleIsAboveEveryGreyDisc = every bigBlackTriangles isAboveEveryGreyDisc

-- Another universe

data Person = Angela | Ben | Claudia | Diana | Emilia
                     | Fangkai | Gavin | Hao | Iain
people :: [Person]
people = [Angela, Ben, Claudia, Diana, Emilia,
                  Fangkai, Gavin, Hao, Iain]

loves :: Relation Person
Angela `loves` Ben = True
Angela `loves` _ = False
Ben `loves` Gavin = True
Ben `loves` _ = False
Claudia `loves` Angela = True
Claudia `loves` Ben = True
Claudia `loves` _ = False
Diana `loves` Hao = True
Diana `loves` Iain = True
Diana `loves` _ = False
Emilia `loves` Fangkai = True
Emilia `loves` _ = False
Fangkai `loves` Diana = True
Fangkai `loves` _ = False
Gavin `loves` Fangkai = True
Gavin `loves` _ = False
Hao `loves` Diana = True
Hao `loves` Fangkai = True
Hao `loves` _ = False
Iain `loves` Emilia = True
Iain `loves` _ = False

angelaLovesSomebody = some people (Angela `loves`)

everybodyLovesBen = every people (`loves` Ben)

somebodyLovesThemself = some people (\x -> x `loves` x)

somebodyLovesSomebodyWhoLovesThem = some people (\x -> some people (\y -> x `loves` y && y `loves` x))

-- Dependencies

forEveryPersonThereIsSomePersonWhoTheyLove = every people (\y -> some people (y `loves`))

thereIsSomePersonWhoEverybodyLoves = some people (\x -> every people (`loves` x))
