-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 24 : Type Classes

module Chap24_type_classes where

-- Bundling types with functions

-- The following function definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (elem)

-- elem :: Eq a => a -> [a] -> Bool
-- x `elem` []     = False
-- x `elem` (y:ys) = x==y || x `elem` ys

data Season = Winter | Spring | Summer | Fall
  deriving (Eq,Show)

-- The following type definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (Maybe, Nothing, Just)

-- data Maybe a = Nothing | Just a
--   deriving (Eq,Show)

-- Declaring instances of type classes

-- The following type class definition and its instances for Char, (a,b) and [a] are commented out because they
-- are already in the Prelude.
-- You can hide that definition and its instances to allow them to be re-defined by putting the following at the
-- top of this module:
-- import Prelude hiding (Eq, (==))

-- class Eq a where
--   (==) :: a -> a -> Bool

-- instance Eq Char where
--   x == y = ord x == ord y

-- instance (Eq a, Eq b) => Eq (a,b) where
--   (u,v) == (x,y) = (u == x) && (v == y)

-- instance Eq a => Eq [a] where
--   [] == []     = True
--   [] == y:ys   = False
--   x:xs == []   = False
--   x:xs == y:ys = (x == y) && (xs == ys)

data Exp = Lit Int
         | Add Exp Exp
         | Mul Exp Exp
  deriving Read

-- showExp and evalExp are from Chapter 16
-- we can't simply import them because Exp has been re-defined
showExp :: Exp -> String
showExp (Lit n)   = show n
showExp (Add e f) = par (showExp e ++ " + " ++ showExp f)
showExp (Mul e f) = par (showExp e ++ " * " ++ showExp f)

par :: String -> String
par s = "(" ++ s ++ ")"

evalExp :: Exp -> Int
evalExp (Lit n)   = n
evalExp (Add e f) = evalExp e + evalExp f
evalExp (Mul e f) = evalExp e * evalExp f

s0 = showExp (read "Add (Lit 3) (Mul (Lit 7) (Lit 2))")

i0 = evalExp (read "Add (Lit 3) (Mul (Lit 7) (Lit 2))")

data Set = MkSet [Int]

instance Eq Set where
  MkSet ms == MkSet ns = ms `subset` ns && ns `subset` ms
    where ms `subset` ns = and [ m `elem` ns | m <- ms ]

b0 = MkSet [1,2] == MkSet [2,1]

data Set' = MkSet' [Int] deriving Eq

b0' = MkSet' [1,2] == MkSet' [2,1]

-- Defining type classes

-- The following type class definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (Show, show)

-- class Show a where
--   show :: a -> String

-- The following type class definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (Eq, (==), (/=))

-- class Eq a where
--   (==) :: a -> a -> Bool
--   (/=) :: a -> a -> Bool
--   -- defaults
--   x /= y = not (x == y)
--   x == y = not (x /= y)

-- The following type class definition and its instances for Bool and Maybe a are commented out because they
-- are already in the Prelude.
-- You can hide that definition and its instances to allow them to be re-defined by putting the following at the
-- top of this module:
-- import Prelude hiding (Ord, (<), (<=), (>), (>=), min, max)

-- class Eq a => Ord a where
--   (<)  :: a -> a -> Bool
--   (<=) :: a -> a -> Bool
--   (>)  :: a -> a -> Bool
--   (>=) :: a -> a -> Bool
--   min  :: a -> a -> a
--   max  :: a -> a -> a
--   -- defaults
--   x < y         = x <= y && x /= y
--   x > y         = y < x
--   x >= y        = y <= x
--   min x y
--     | x <= y    = x
--     | otherwise = y
--   max x y
--     | x <= y    = y
--     | otherwise = x

-- The following type definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (Bool, True, False)

-- data Bool = False | True
--   deriving (Eq,Show,Ord)

-- instance Ord Bool where
--   False <= False = True
--   False <= True  = True
--   True  <= False = False
--   True  <= True  = True

-- The following type definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (Maybe, Nothing, Just)

-- data Maybe a = Nothing | Just a
--   deriving (Eq,Show,Ord)

-- instance Ord a => Ord (Maybe a) where
--   Nothing <= Nothing = True
--   Nothing <= Just x  = True
--   Just x  <= Nothing = False
--   Just x  <= Just y  = x <= y

data Pair a b = Pair a b
  deriving (Eq,Show,Ord)
           
-- The following type instance declaration is commented out because it duplicates the derived instance Ord (Pair a b).
-- You can hide the derived instance by changing the definition of Pair a b to
-- data Pair a b = Pair a b
--   deriving (Eq,Show)

-- instance (Ord a, Ord b) => Ord (Pair a b) where
--   Pair x y <= Pair x' y' = x < x' || (x == x' && y <= y')

b1 = Pair 1 35 <= Pair 2 7 -- 1st components determine result

b2 = Pair 1 35 <= Pair 1 7 -- 1st components equal, compare 2nd components

-- The following type instance declaration is commented out because it duplicates the derived instance Ord (Pair a b).
-- You can hide the derived instance by changing the definition of Pair a b to
-- data Pair a b = Pair a b
--   deriving (Eq,Show)

-- instance (Ord a, Ord b) => Ord (Pair a b) where
--   Pair x y <= Pair x' y' = x < x' || (x == x' && y <= y')
--   Pair x y < Pair x' y'  = x < x' || (x == x' && y < y')

data List a = Nil
            | Cons a (List a)
  deriving (Eq,Show,Ord)

-- The following type instance declaration is commented out because it duplicates the derived instance Ord (List a).
-- You can hide the derived instance by changing the definition of List a to
-- data List a = Nil
--             | Cons a (List a)
--   deriving (Eq,Show)

-- instance Ord a => Ord (List a) where
--   Nil       <= ys        = True
--   Cons x xs <= Nil       = False
--   Cons x xs <= Cons y ys = x < y || (x == y && xs <= ys)

b3 = Cons 1 (Cons 35 Nil) <= Cons 2 (Cons 7 Nil)

b4 = Cons 1 (Cons 35 Nil) <= Cons 1 (Cons 7 Nil)

b5 = "ashen" <= "asia" -- 'a'=='a', 's'=='s', 'h'<='i'

b6 = "ash" <= "as"     -- 'a'=='a', 's'=='s', "h" <= "" is False

-- The following type class definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (Enum, toEnum, fromEnum, succ, pred, enumFrom, enumFromTo, enumFromThen, enumFromThenTo)

-- class Enum a where
--   toEnum         :: Int -> a
--   fromEnum       :: a -> Int
--   succ, pred     :: a -> a
--   enumFrom       :: a -> [a]            -- [x ..]
--   enumFromTo     :: a -> a -> [a]       -- [x .. y]
--   enumFromThen   :: a -> a -> [a]       -- [x, y ..]
--   enumFromThenTo :: a -> a -> a -> [a]  -- [x, y .. z]
-- 
--   -- defaults
--   succ x = toEnum (fromEnum x + 1)
--   pred x = toEnum (fromEnum x - 1)
--   enumFrom x
--     = map toEnum [fromEnum x ..]
--   enumFromTo x y
--     = map toEnum [fromEnum x .. fromEnum y]
--   enumFromThen x y
--     = map toEnum [fromEnum x, fromEnum y ..]
--   enumFromThenTo x y z
--     = map toEnum [fromEnum x, fromEnum y .. fromEnum z]

instance Enum Season where
  toEnum 0 = Winter
  toEnum 1 = Spring
  toEnum 2 = Summer
  toEnum 3 = Fall
  
  fromEnum Winter = 0
  fromEnum Spring = 1
  fromEnum Summer = 2
  fromEnum Fall   = 3

data Season' = Winter' | Spring' | Summer' | Fall'
  deriving (Eq,Show,Enum)

l0 = [Spring' .. Fall']

l1 = [Fall', Summer' ..]

-- Numeric type classes

-- The following type class definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (Num, (+), (-), (*), negate, abs, signum, fromInteger)

-- class (Eq a, Show a) => Num a where  
--   (+), (-), (*) :: a -> a -> a  
--   negate        :: a -> a  
--   abs, signum   :: a -> a  
--   fromInteger   :: Integer -> a
--   -- default
--   negate x = fromInteger 0 - x

-- The following type class definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (Fractional, (/), recip, fromRational)

-- class Num a => Fractional a where
--   (/)          :: a -> a -> a
--   recip        :: a -> a
--   fromRational :: Rational -> a
--   -- default
--   recip x = 1/x

-- The following type class definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (Floating, pi, exp, log, sqrt, (**), logBase, sin, cos, tan, asin, acos, atan, sinh, cosh, tanh, asinh, acosh, atanh)

-- class Fractional a => Floating a where
--   pi                  :: a
--   exp, log, sqrt      :: a -> a
--   (**), logBase       :: a -> a -> a
--   sin, cos, tan       :: a -> a
--   asin, acos, atan    :: a -> a
--   sinh, cosh, tanh    :: a -> a
--   asinh, acosh, atanh :: a -> a
--   
--   -- defaults
--   x ** y      = exp (log x * y)
--   logBase x y = log y / log x
--   sqrt x      = x ** 0.5
--   tan  x      = sin  x / cos  x
--   tanh x      = sinh x / cosh x

-- Functors

-- The following type class definition and its instances for [] and Maybe are commented out because they
-- are already in the Prelude.
-- You can hide that definition and its instances to allow them to be re-defined by putting the following at the
-- top of this module:
-- import Prelude hiding (Functor, fmap)

-- class Functor t where  
--   fmap :: (a -> b) -> t a -> t b

l2 = map even [1,2,3,4,5]

-- instance Functor [] where
--   fmap = map

-- instance Functor Maybe where
--   fmap f (Just x) = Just (f x)
--   fmap f Nothing  = Nothing

squares :: Functor t => t Int -> t Int
squares = fmap (^2)

l3 = squares [2..10]

l4 = squares (Just 3)

class Bifunctor t where
  bimap :: (a -> b) -> (c -> d) -> t a c -> t b d

instance Bifunctor Either where
  bimap f g (Left x)  = Left (f x)
  bimap f g (Right y) = Right (g y)

instance Bifunctor Pair where
  bimap f g (Pair x y) = Pair (f x) (g y)

-- Type classes are syntactic sugar

elem' :: Eq a => a -> [a] -> Bool
elem' x []     = False
elem' x (y:ys) = x==y || elem' x ys

elem'' :: (a -> a -> Bool) -> a -> [a] -> Bool
elem'' eq x []     = False
elem'' eq x (y:ys) = x `eq` y || elem'' eq x ys


b7 = elem' 5 [1..10]

b7' = elem'' eqInt 5 [1..10]
  where eqInt :: Int -> Int -> Bool
        eqInt = (==)

eqList :: (a -> a -> Bool) -> [a] -> [a] -> Bool
eqList eq [] []         = True
eqList eq [] (y:ys)     = False
eqList eq (x:xs) []     = False
eqList eq (x:xs) (y:ys) = (x `eq` y) && (eqList eq xs ys)

b8 = elem' "of" ["list","of","strings"]

b8' = elem'' (eqList eqChar) "of" ["list","of","strings"]
  where eqChar :: Char -> Char -> Bool
        eqChar = (==)
