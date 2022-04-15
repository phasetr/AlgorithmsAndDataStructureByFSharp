module S8_2 where
import Search ( searchDfs, firstNq, countNq, succKnp, goalKnp, knapsack )
import Sort ( qsort )

--Example in the book
main :: IO ()
main = do
  --PUT WEIGHT FIRST FIRST
  -- Brassard and Bratley p. 307
  print $ knapsack [(2,3),(3,5),(4,6),(5,10)] 8 == ([(5,10.0),(3,5.0)],15.0)
  -- print $ ? dfs8Tile  -- never terminated....
  print $ firstNq 8 == [(1,1),(2,5),(3,8),(4,6),(5,3),(6,7),(7,2),(8,4)]
  print $ countNq 8 == 92
  print $ k == ([(3,5.0),(3,5.0),(2,3.0),(2,3.0)],16.0)
  print $ k' == ([(6,13.0),(6,13.0),(6,13.0),(6,13.0),(6,13.0),(3,6.0),(2,4.0)],75.0)
  print $ k'' == ([(3,4.4),(3,4.4),(2,2.8),(2,2.8)],14.4)
  print $ test == [([(2,2.8),(2,2.8),(2,2.8),(2,2.8),(2,2.8)],14.0),([(3,4.4),(2,2.8),(2,2.8),(2,2.8)],12.799999),([(3,4.4),(3,4.4),(2,2.8),(2,2.8)],14.4),([(5,6.1),(2,2.8),(2,2.8)],11.7),([(3,4.4),(3,4.4),(2,2.8)],11.6),([(5,6.1),(3,4.4),(2,2.8)],13.299999),([(3,4.4),(3,4.4),(3,4.4)],13.200001),([(5,6.1),(3,4.4)],10.5),([(5,6.1),(5,6.1)],12.2)]
  where
    k = knapsack [(2,3),(3,5),(5,6)] 10
    k' = knapsack [(8,15),(15,10),(3,6),(6,13),(2,4),(4,8),(5,6),(7,7)] 35
    k''= knapsack [(2,2.8),(3,4.4),(5,6.1)] 10
    -- FOR DISPLAYING FIGURE ONLY
    knp objects limit = [(sol,v) | (v,w,_,_,sol) <- searchDfs succKnp goalKnp (0,0,limit,qsort objects,[]), w==10 || w==9 ||w==8]
    test = knp [(2,2.8),(3,4.4),(5,6.1)] 10
