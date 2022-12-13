module Ex14 where
import Sec1406 hiding (build)
-- P.361 Exercise14.12, P.364 Answer14.12
build = endstep . foldr step [] . zip (map Leaf [1..])
endstep :: [Pair] -> Tree Label
endstep [(t,_)] = t
endstep (x:y:xs) = endstep (insert (join x y) xs)
