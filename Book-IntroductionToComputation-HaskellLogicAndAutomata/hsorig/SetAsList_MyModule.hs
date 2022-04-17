-- D. Sannella. M Fourman, H. Peng and P. Wadler
-- Introduction to Computation: Haskell, Logic and Automata
-- Undergraduate Topics in Computer Science, Springer (2021)
-- ISBN 978-3-030-76907

-- Chapter 21 : Data Abstraction

-- Sets as lists: problems

module SetAsList_MyModule where
  import SetAsList
  
  intersect :: Set -> Set -> Set
  ms `intersect` ns = [ m | m <- ms, m `elem` ns ]
  
  intersect_prop :: Set -> Set -> Bool
  intersect_prop ns ms = (ns `intersect` ms) `equal` (ms `intersect` ns)

  select :: Set -> Int
  select ns = head ns

  b0 = ([1,2] `intersect` [3,2,1]) `equal` ([3,2,1] `intersect` [1,2])

  i0 = select ([1,2] `intersect` [3,2,1])

  i0' = select ([3,2,1] `intersect` [1,2])
  
  b1 = set [1,2] `equal` set [2,1]

  i1 = select (set [1,2])

  i1' = select (set [2,1])
  
