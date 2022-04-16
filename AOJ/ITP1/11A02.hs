-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_A/review/2214813/aimy/Haskell
main :: IO ()
main = getContents >>= putStrLn . solve
  . (\[ns,os] -> (words ns, os)) . lines

solve :: Foldable t => ([a], t Char) -> a
solve (ns,os) = ns !! (head (foldl roll [1,2,3] os) - 1) where
  roll [x,y,z] 'E' = [7-z,y,x]
  roll [x,y,z] 'N' = [y,7-x,z]
  roll [x,y,z] 'S' = [7-y,x,z]
  roll [x,y,z] 'W' = [z,y,7-x]
  roll _ _ = undefined
