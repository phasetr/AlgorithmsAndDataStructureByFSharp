-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 21 : Data Abstraction

module Chap21_data_abstraction where

-- Four ways of representing sets:
--
--   1. sets as lists (SetAsList)
--   2. sets as ordered lists without duplicates (SetAsOrderedList)
--   3. sets as ordered trees (SetAsOrderedTree)
--   4. sets as AVL trees (SetAsAVLTree)
--
-- and problems with abstraction barriers
--
--   5. abstraction barriers: SetAsOrderedTree and SetAsAVLTree
--      with improved versions in AbstractSetAsOrderedTree and AbstractSetAsAVLTree
--   6. abstraction barriers: SetAsList and SetAsOrderedList
--      with an improved version of SetAsList in AbstractSetAsList
--      (but not AbstractSetAsOrderedList, which is Exercise 4)
--
-- are given in separate files in order to avoid name clashes

