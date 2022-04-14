module S7_4 where
import Data.Array ( Ix )
import Graph ( mkGraph )
import Sort ( topologicalSort )

data Courses =
  Maths | Theory | Languages | Programming | Concurrency | Architecture | Parallelism
             deriving (Eq,Ord,Enum,Ix,Show)

main :: IO ()
main = do
  print $ topologicalSort g == [1,3,6,5,4,2]
  print $ topologicalSort cg == [Architecture,Programming,Concurrency,Parallelism,Languages,Maths,Theory]
  where
    g = mkGraph True (1,6) [(1,2,0),(1,3,0),(1,4,0),(3,6,0),(5,4,0),(6,2,0),(6,5,0)]
    cg = mkGraph True (Maths,Parallelism)
         [(Maths,Theory,1)
          ,(Languages,Theory,1)
          ,(Programming,Languages,1)
          ,(Programming,Concurrency,1)
          ,(Concurrency,Parallelism,1)
          ,(Architecture,Parallelism,1)]
