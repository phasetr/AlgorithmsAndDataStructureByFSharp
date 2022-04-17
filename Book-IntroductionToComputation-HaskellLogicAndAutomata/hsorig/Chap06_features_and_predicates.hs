-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 6 : Features and Predicates

module Chap06_features_and_predicates where

-- Representing the universe

data Thing = R | S | T | U | V | W | X | Y | Z deriving (Eq,Show)
things :: [Thing]
things = [R, S, T, U, V, W, X, Y, Z]

data Colour = White | Black | Grey
data Shape = Disc | Triangle
data Size = Big | Small

colour :: Thing -> Colour
colour R = Grey
colour S = Grey
colour T = Black
colour U = White
colour V = White
colour W = Grey
colour X = Black
colour Y = Grey
colour Z = Black

shape :: Thing -> Shape
shape R = Disc
shape S = Triangle
shape T = Triangle
shape U = Disc
shape V = Triangle
shape W = Triangle
shape X = Triangle
shape Y = Triangle
shape Z = Disc

size :: Thing -> Size
size R = Small
size S = Small
size T = Big
size U = Big
size V = Small
size W = Big
size X = Small
size Y = Big
size Z = Big

type Predicate u = u -> Bool

isDisc :: Predicate Thing
isDisc x = x `elem` [R, U, Y, Z]

isTriangle :: Predicate Thing
isTriangle x = not (isDisc x)

isWhite :: Predicate Thing
isWhite x = x `elem` [U, V]

isBlack :: Predicate Thing
isBlack x = x `elem` [T, X, Z]

isGrey :: Predicate Thing
isGrey x = not (isWhite x || isBlack x)

isBig :: Predicate Thing
isBig x = not (isSmall x)

isSmall :: Predicate Thing
isSmall x = x `elem` [R, S, V, X]

-- Things having more complex properties

smallTriangles = [ x | x <- things, isSmall x, isTriangle x ]

smallTriangles' = [ x | x <- things, isSmall x && isTriangle x ]

greyDiscs = [ x | x <- things, isGrey x && isDisc x ]

bigOrTriangles = [ x | x <- things, isBig x || isTriangle x ]

bigTriangles = [ x | x <- things, isBig x && isTriangle x ]

nonGreyDiscs = [ x | x <- things, isDisc x && not (isGrey x) ]

smalls = [ x | x <- things, isSmall x ]

triangles = [ x | x <- things, isTriangle x ]

-- Checking which statements hold

smallTrianglesAreWhite = [ (x, isWhite x) | x <- things, isSmall x && isTriangle x ]

smallTrianglesAreWhite' = and [ isWhite x | x <- things, isSmall x && isTriangle x ]

whiteTrianglesAreSmall = and [ isSmall x | x <- things, isWhite x && isTriangle x ]

bigTrianglesAreGrey = [ (x,isGrey x) | x <- things, isBig x && isTriangle x ]

bigTrianglesAreGrey' = or [ isGrey x | x <- things, isBig x && isTriangle x ]

smallDiscsAreBlack = or [ isBlack x | x <- things, isSmall x && isDisc x ]
