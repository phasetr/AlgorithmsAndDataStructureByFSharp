module S5_4 where
import PQueue (emptyPQ,enPQ,frontPQ,dePQ)

test = print $ show (foldr enPQ emptyPQ [3,1,7,2,9]) == "PQ (HP 1 2 (HP 2 2 (HP 9 1 EmptyHP EmptyHP) (HP 7 1 EmptyHP EmptyHP)) (HP 3 1 EmptyHP EmptyHP))"
  && show (frontPQ pq, dePQ pq) == "(1,PQ (HP 2 2 (HP 9 1 EmptyHP EmptyHP) (HP 3 1 (HP 7 1 EmptyHP EmptyHP) EmptyHP)))"
  where pq = foldr enPQ emptyPQ [3,1,7,2,9]

