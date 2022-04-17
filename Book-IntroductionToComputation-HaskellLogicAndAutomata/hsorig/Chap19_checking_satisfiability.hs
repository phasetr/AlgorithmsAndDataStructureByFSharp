-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 19 : Checking Satisfiability

module Chap19_checking_satisfiability where

import Chap06_features_and_predicates (Thing)

import Chap16_expression_trees (Prop (Var, Not, (:||:), (:&&:)))

import Data.List (intercalate, intersperse, delete, sortOn)

import Data.Char (intToDigit)

-- Representing CNF

cnf = 
  (Not (Var "A") :||: Not (Var "B") :||: (Var "C"))
  :&&: (Not (Var "A") :||: (Var "D") :||: (Var "F"))
  :&&: ((Var "A") :||: (Var "B") :||: (Var "E"))
  :&&: ((Var "A") :||: (Var "B") :||: Not (Var "C"))

data Var = A | B | C | D | E | F | G | H
  deriving (Eq,Show)

data PredApp = IsDisc Thing
             | IsTriangle Thing
             | IsWhite Thing
             | IsBlack Thing
             | IsGrey Thing
             | IsBig Thing
             | IsSmall Thing
  deriving (Eq,Show)

data Literal atom = P atom | N atom
  deriving Eq

data Clause atom = Or [Literal atom]
  deriving Eq

c0 = Or [P A, N B, N C]

c1 = Or [N A]

c2 = Or []

data Form atom = And [Clause atom]
  deriving Eq

cnf' = 
  And [Or [N A, N B, P C],
       Or [N A, P D, P F],
       Or [P A, P B, P E],
       Or [P A, P B, N C]]

cnf'' = And [Or [P A, N B, N C], Or []] 

instance Show a => Show (Literal a) where
  show (P x) = show x
  show (N x) = "not " ++ show x

instance Show a => Show (Clause a) where
  show (Or ls) = "(" ++ intercalate " || " (map show ls) ++ ")"
  
instance Show a => Show (Form a) where
  show (And ls) = intercalate " && " (map show ls)

-- The DPLL algorithm: implementation

(<<) :: Eq atom => [Clause atom] -> Literal atom -> [Clause atom]
cs << l = [ Or (delete (neg l) ls)
            | Or ls <- cs, not (l `elem` ls) ]

neg :: Literal atom -> Literal atom
neg (P a) = N a
neg (N a) = P a

example1 = cnf'

example2 =
  And [Or [N A, P C, P D],
       Or [N B, P F, P D],
       Or [N B, N F, N C],
       Or [N D, N B],
       Or [P B, N C, N A],
       Or [P B, P F, P C],
       Or [P B, N F, N D],
       Or [P A, P E],
       Or [P A, P F],
       Or [N F, P C, N E],
       Or [P A, N C, N E]]

dpll :: Eq atom => Form atom -> [[Literal atom]]
dpll (And [])               = [[]]  -- one trivial solution
dpll (And (Or [] : cs))     = []    -- no solution
dpll (And (Or (l:ls) : cs)) =
  [ l : ls | ls <- dpll (And (cs << l)) ]
  ++
  [ neg l : ls | ls <- dpll (And (Or ls : cs << neg l)) ]

b1 = dpll example1

b2 = dpll example2

dpll' :: Eq atom => Form atom -> [[Literal atom]]
dpll' f =
  case prioritise f of
    []             -> [[]]  -- the trivial solution
    Or [] : cs     -> []    -- no solution
    Or (l:ls) : cs ->
      [ l : ls | ls <- dpll' (And (cs << l)) ]
      ++
      [ neg l : ls | ls <- dpll' (And (Or ls : cs << neg l)) ]

prioritise :: Form atom -> [Clause atom]
prioritise (And cs) = sortOn (\(Or ls) -> length ls) cs

b1' = dpll' example1

b2' = dpll' example2

-- Application: Sudoku

allFilled :: Form (Int,Int,Int)
allFilled = And [ Or [ P (i,j,n) | n <- [1..9] ]
                  | i <- [1..9], j <- [1..9] ]

noneFilledTwice :: Form (Int,Int,Int)
noneFilledTwice = And [ Or [ N (i, j, n), N (i, j, n') ]
                        | i <- [1..9], j <- [1..9],
                          n <- [1..9], n' <- [1..(n-1)]]

rowsComplete :: Form (Int,Int,Int)
rowsComplete = And [ Or [ P (i, j, n) | j <- [1..9] ]
                     | i <- [1..9], n <- [1..9] ]

columnsComplete :: Form (Int,Int,Int)
columnsComplete = undefined

squaresComplete :: Form (Int,Int,Int)
squaresComplete = undefined

sudokuProblem =
  And [Or [P (1,2,9)], Or [P (1,9,2)],
       Or [P (2,5,9)], Or [P (2,7,4)], Or [P (2,8,6)], Or [P (2,9,3)],
       Or [P (3,1,3)], Or [P (3,3,6)], Or [P (3,6,8)], Or [P (3,7,1)],
       Or [P (4,1,6)], Or [P (4,4,9)], Or [P (4,7,3)],
       Or [P (5,1,9)], Or [P (5,4,8)], Or [P (5,6,2)], Or [P (5,9,1)],
       Or [P (6,3,2)], Or [P (6,6,7)], Or [P (6,9,5)],
       Or [P (7,3,3)], Or [P (7,4,5)], Or [P (7,7,7)], Or [P (7,9,4)],
       Or [P (8,1,5)], Or [P (8,2,1)], Or [P (8,3,7)], Or [P (8,5,8)],
       Or [P (9,1,4)], Or [P (9,8,1)]]

(<&&>) :: Form a -> Form a  -> Form a  
And xs <&&> And ys = And ( xs ++ ys )

sudoku =
  allFilled <&&> noneFilledTwice <&&> rowsComplete
  <&&> columnsComplete <&&> squaresComplete
  <&&> sudokuProblem

rowsNoRepetition :: Form (Int,Int,Int)
rowsNoRepetition = And [ Or [ N (i, j, n), N (i, j', n) ]
                         | i <- [1..9], n <- [1..9],
                           j <- [1..9], j' <- [1..(j-1)] ]

columnsNoRepetition :: Form (Int,Int,Int)
columnsNoRepetition = undefined

squaresNoRepetition :: Form (Int,Int,Int)
squaresNoRepetition = undefined

sudoku' =
  allFilled <&&> noneFilledTwice <&&> rowsComplete
  <&&> columnsComplete <&&> squaresComplete
  <&&> sudokuProblem <&&> rowsNoRepetition
  <&&> columnsNoRepetition <&&> squaresNoRepetition

-- Pretty printing for Sudoku problems and solutions
--
-- printProblem sudokuProblem
--   pretty prints sudokuProblem
--
-- printAllSolutions sudokuProblem
--   pretty prints all solutions to sudokuProblem
-- 
-- printSolution . head . dpll' $ sudokuProblem
--   pretty prints the first solution to sudokuProblem

toLiterals :: Form atom -> [Literal atom]
toLiterals (And clauses) = concat $ map unpack clauses
    where unpack (Or literals) = literals
                                 
showSquares :: [Literal (Int,Int,Int)] -> String
showSquares lits =
  let pos = [ a | P a <- lits ]
  in
   [ (intToDigit.last) [ k | k <-[0..9]
                       , (i, j, k)`elem`pos || k == 0 ]
   | i <- [1..9], j <- [1..9] ]
  
-- | pretty takes an 81 digit string and presents it in sudoku form
-- using unicode -- suitable for putStrLn
pretty :: String -> String
pretty = ((tl++dsh++dn++dsh++dn++dsh++tr++"\n"++vt++" ")++)
         . (++(" "++vt++" \n"++bl++dsh++up++dsh++up++dsh++br))
         . intercalate (" "++vt++"\n"++vl++dsh++pl++dsh++pl++dsh++vr++" \n"++vt++" ")
         . map (intercalate (" "++vt++"\n"++vt++" ")) . byThree
         . map (intercalate (" "++vt++" ")). byThree
         . map (intersperse ' ')  . byThree
         . map (\d -> if d == '0' then '\x005F' else d)
  where
    byThree :: [a] -> [[a]]
    byThree (a : b : c : xs) = [a,b,c] : byThree xs
    byThree [] = []
    tl = "\x250F" -- topleft
    tr = "\x2513" -- topright
    bl = "\x2517" -- botleft
    br = "\x251B" -- botright
    dn = "\x2533"
    up = "\x253B"
    vl = "\x2523" -- vertleft
    vr = "\x252B" -- vertright
    vt = "\x2503" -- vertical
    pl = "\x254B" -- plus
    dsh = take 7 $ repeat '\x2501'
  
printProblem :: Form (Int, Int, Int) -> IO ()
printProblem = putStrLn . pretty . showSquares . toLiterals

printSolution :: [Literal (Int, Int, Int)] -> IO ()
printSolution = putStrLn . pretty . showSquares

printAllSolutions :: Form (Int, Int, Int) -> IO ()
printAllSolutions = mapM_ printSolution . dpll'
