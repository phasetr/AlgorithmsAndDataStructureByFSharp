-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Required to allow type signatures in type class instance declarations

{-# LANGUAGE InstanceSigs #-}

-- Chapter 30 : Input/Output and Monads

module Chap30_input_output_and_monads where
       
import Data.Char (toUpper, isDigit)

import Control.Monad (liftM, ap)

import Control.Applicative (Alternative, empty, (<|>))

-- Commands

c0 = putChar 'a' >> putChar 'b'

-- The following function definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (putStr)

-- putStr :: String -> IO ()
-- putStr []     = done
-- putStr (x:xs) = putChar x >> putStr xs

-- The following function definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (putStrLn)

-- putStrLn :: String -> IO ()
-- putStrLn cs = putStr cs >> putChar '\n'

-- Performing commands

c1 = putStrLn "Hello World!"

c2 = putStr "Boing" >> putStr "Boing"

c2' = m >> m
        where m = putStr "Boing"

-- Commands that return a value

c3 = getChar >>= \x -> putChar (toUpper x)

-- The following function definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding (getLine)

-- getLine :: IO String
-- getLine =
--   getChar                         -- read a character
--     >>= \x ->                     -- and call it x
--           if x == '\n'            -- if it's newline, we're done
--             then return ""        -- so return the empty string
--           else                    -- otherwise
--             getLine               -- read the rest of the line
--               >>= \xs ->          -- and call it xs
--                     return (x:xs) -- and then return x:xs

echo :: IO ()
echo =
  getLine
    >>= \line ->
          if line == "" then
            return ()
          else
            putStrLn (map toUpper line)
              >> echo

done :: IO ()
done = return ()

-- The following function definition is commented out because it is already in the Prelude.
-- You can hide that definition to allow it to be re-defined by putting the following at the top of this module:
-- import Prelude hiding ( (>>) )
-- But then, in order to get later code to typecheck, you will need to give it the more general type
-- (>>) :: Monad m => m a -> m b -> m b

-- (>>) :: IO () -> IO () -> IO ()
-- m >> n = m >>= \_ -> n

-- do notation

getLine' :: IO String
getLine' = do {
             x <- getChar;
             if x == '\n' then
               return ""
             else do {
               xs <- getLine;
               return (x:xs)
                  }
           }

putStr' :: String -> IO ()
putStr' []     = done
putStr' (x:xs) = do {
                   putChar x;
                   putStr' xs
                 }

-- Monads

-- The following type class definition and its instance for [] are commented out because they are already
-- in the Prelude.
-- You can hide that definition and its instances to allow them to be re-defined by putting the following at the
-- top of this module:
-- import Prelude hiding (Monad, return, (>>=), (>>))
-- but then the earlier definitions using the IO monad won't compile unless you re-define it too.

-- class Monad m where
--   return :: a -> m a
--   (>>=)  :: m a -> (a -> m b) -> m b
--   -- default
--   (>>)   :: m a -> m b -> m b
--   x >> y = x >>= \_ -> y

-- Lists as a monad

-- instance Monad [] where
--   return  :: a -> [a]
--   return x = [ x ]
--  
--   (>>=)   :: [a] -> (a -> [b]) -> [b]
--   m >>= k = [ y | x <- m, y <- k x ]

-- alternative definition of >>=
-- [] >>= k     = []
-- (x:xs) >>= k = (k x) ++ (xs >>= k)

-- another alternative definition of >>=
-- m >>= k = concat (map k m)

pairs :: Int -> [(Int, Int)]
pairs n = do {
            i <- [1..n];
            j <- [(i+1)..n];
            return (i,j)
          }

ps0 = pairs 4

pairs' :: Int -> [(Int, Int)]
pairs' n = [ (i,j) | i <- [1..n], j <- [(i+1)..n] ]

class Monad m => MonadPlus m where
  mzero :: m a
  mplus :: m a -> m a -> m a

instance MonadPlus [] where
  mzero :: [a]
  mzero = []

  mplus :: [a] -> [a] -> [a]
  mplus = (++)

guard :: MonadPlus m => Bool -> m ()
guard False = mzero
guard True  = return ()

l0 = guard (1 > 3) :: [()]

l1 = guard (3 > 1) :: [()]

l2 = guard (1 > 3) >> return 1 :: [Int]

l3 = guard (3 > 1) >> return 1 :: [Int]

pairs'' :: Int -> [(Int, Int)]
pairs'' n = do {
              i <- [1..n];
              j <- [1..n];
              guard (i < j);
              return (i,j)
            }
ps1 = pairs'' 4

pairs''' :: Int -> [(Int, Int)]
pairs''' n = [ (i,j) | i <- [1..n], j <- [1..n], i < j ]

-- Parsers as a monad

data Exp = Lit Int
         | Add Exp Exp
         | Mul Exp Exp
  deriving (Eq, Show)

-- showExp is from Chapter 16
-- we can't simply import it because Exp has been re-defined

showExp :: Exp -> String
showExp (Lit n)   = show n
showExp (Add e f) = par (showExp e ++ " + " ++ showExp f)
showExp (Mul e f) = par (showExp e ++ " * " ++ showExp f)

par :: String -> String
par s = "(" ++ s ++ ")"

s0 = showExp (Add (Lit 1) (Mul (Lit 2) (Lit 3)))

s1 = showExp (Mul (Add (Lit 1) (Lit 2)) (Lit 3))

data Parser a = Parser (String -> [(a, String)])

apply :: Parser a -> String -> [(a, String)]
apply (Parser f) s = f s

parse :: Parser a -> String -> a
parse p s = one [ x | (x,"") <- apply p s ]
  where one []                 = error "no parse"
        one [x]                = x
        one xs | length xs > 1 = error "ambiguous parse"

char :: Parser Char
char = Parser f
  where f []    = []
        f (c:s) = [(c,s)]

spot :: (Char -> Bool) -> Parser Char
spot p = Parser f
  where f []                = []
        f (c:s) | p c       = [(c, s)]
                | otherwise = []

token :: Char -> Parser Char
token c = spot (== c)

ps2 = apply (spot isDigit) "123"

ps3 = apply (spot isDigit) "(1+2)"

ps4 = apply (token '(') "(1+2)"

instance Monad Parser where
  return x = Parser (\s -> [(x,s)])
  m >>= k  = Parser (\s ->
               [ (y, u) |
                 (x, t) <- apply m s,
                 (y, u) <- apply (k x) t ])

-- from Haskell 7.10, need to add instances for Functor and Applicative

instance Functor Parser where
  fmap = liftM

instance Applicative Parser where
  pure  = return
  (<*>) = ap

match :: String -> Parser String
match []     = return []
match (x:xs) = do {
                 y <- token x;
                 ys <- match xs;
                 return (y:ys)
               }

ps5 = apply (match "abc") "abcdef"

ps6 = apply (do {x <- match "abc"; y <- match "de"; return (x++y) }) "abcdef"

instance MonadPlus Parser where
  mzero     = Parser (\s -> [])
  mplus m n = Parser (\s -> apply m s ++ apply n s)

-- ** from Haskell 7.10, need to add instance for Alternative

instance Alternative Parser where
  empty = mzero
  (<|>) = mplus

spot' :: (Char -> Bool) -> Parser Char
spot' p = do {
            c <- char;
            guard (p c);
            return c
          }

star :: Parser a -> Parser [a]
star p = plus p `mplus` return []

plus :: Parser a -> Parser [a]
plus p = do {
           x <- p;
           xs <- star p;
           return (x:xs)
         }

parseInt :: Parser Int
parseInt = parseNat `mplus` parseNeg
  where parseNat = do {
                     s <- plus (spot isDigit);
                     return (read s)
                   }
        parseNeg = do {
                     token '-';
                     n <- parseNat;
                     return (-n)
                   }

ps7 = apply parseInt "-123+4"

parseExp :: Parser Exp
parseExp = parseLit `mplus` parseAdd `mplus` parseMul
  where parseLit = do {
                     n <- parseInt;
                     return (Lit n)
                   }
        parseAdd = do {
                     token '(';
                     d <- parseExp;
                     token '+';
                     e <- parseExp;
                     token ')';
                     return (Add d e)
                   }
        parseMul = do {
                     token '(';
                     d <- parseExp;
                     token '*';
                     e <- parseExp;
                     token ')';
                     return (Mul d e)
                   }

ps8 = parse parseExp "(-142+(26*3))"

ps9 = parse parseExp "((-142+26)*3)"

ps10 = parse parseExp "(-142+26)*3"
