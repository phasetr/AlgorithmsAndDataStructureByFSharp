-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 21 : Data Abstraction

-- Sets as ordered lists without duplicates: problems

module SetAsOrderedList_MyModule where
  import SetAsOrderedList
  
  intersect :: Set -> Set -> Set
  ms `intersect` ns = [ m | m <- ms, m `elem` ns ]
  
  intersect_prop :: Set -> Set -> Bool
  intersect_prop ns ms = (ns `intersect` ms) `equal` (ms `intersect` ns)

  select :: Set -> Int
  select ns = head ns

  s0 = [4,1,3] `union` [2,4,5,6]

  b0 = 1 `element` s0

  badUnion :: Set -> Set -> Set
  ms `badUnion` ns = ms ++ ns

  s1 = set [3,1]

  s2 = set [2,1,2]

  s3 = set [3,1] `badUnion` set [2,1,2]

  b3 = 2 `element` s3
