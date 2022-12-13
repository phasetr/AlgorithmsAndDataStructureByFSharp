-- P.241, 10.1 Theory
module Sec1001 where

-- P.241
--ThinBy :: (a -> a -> Bool) -> [a] -> [a]
--ThinBy = undefined
-- P.242
thinBy :: Foldable t => (a -> a -> Bool) -> t a -> [a]
thinBy (≼) = foldr bump []
  where
    bump x [] = [x]
    bump x (y:ys)
      | x ≼ y = x:ys
      | y ≼ x = y:ys
      | otherwise = x:y:ys
{-
thinBy (≼) [(1,2),(4,3),(2,3),(5,4),(3,1)] == [(1,2),(4,3),(5,4),(3,1)]
thinBy (≼) [(1,2),(2,3),(3,1),(4,3),(5,4)] == [(3,1),(4,3),(5,4)]
thinBy (≼) [(3,1),(1,2),(2,3),(4,3),(5,4)] == [(3,1),(4,3),(5,4)]
-}
