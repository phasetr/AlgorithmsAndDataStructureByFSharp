-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 4 : Venn Diagrams and Logical Connectives

module Chap04_venn_diagrams_and_logical_connectives where

-- Truth tables

complicated :: Bool -> Bool -> Bool -> Bool -> Bool
complicated a b c d =
  (a && not b && (c || (d && b)) || (not b && not a)) && c

