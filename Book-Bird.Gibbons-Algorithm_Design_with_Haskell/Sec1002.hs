-- P.244 10.2 Paths in a layered network
module Sec1002 where
import Lib (minWith)
import Sec1001 (thinBy)

-- P.245
type Net = [[Edge]]
type Path = [Edge]
type Edge = (Vertex,Vertex,Weight)
type Vertex = Int
type Weight = Int

-- P.245
source, target :: Edge -> Vertex
source (u,v,w) = u
target (u,v,w) = v

weight :: Edge -> Weight
weight (u,v,w) = w

-- P.245, mcp = a minimum-cost path
mcp :: Net -> Path
mcp = MinWith cost . paths
cost  :: Path -> Int
cost = sum . map weight
-- P.245
cp :: [[a]] -> [[a]]
cp = foldr op [[]] where op xs yss = [x:ys | x <- xs, ys <- yss]
--cp ["abc","de","f"] = ["adf","aef","bdf","bef","cdf","cef"]

-- P.245
paths :: Net -> [Path]
paths = filter connected . cp

connected  :: Path -> Bool
connected [] = True
connected (e:es) = linked e es && connected es

-- P.246
linked :: Edge -> Path -> Bool
linked e1 [] = True
linked e1 (e2:es) = target e1 == source e2

-- P.246
paths2 :: Net -> [Path]
paths2 = foldr step [[]]
  where step es ps = [e:p | e <- es, p <- ps, linked e p]

-- P.246
step2 es ps = concat [cons e ps | e <- es]
  where cons e ps = [e:p | p <- ps,linked e p]

-- P.246
(≼) :: Path -> Path -> Bool
p1 ≼ p2 = source (head p1) == source (head p2) && cost p1 <= cost p2

-- P.247
mcp = minWith cost . foldr tstep [[]]
  where tstep es ps = thinBy (≼) [e:p | e <- es, p <- ps, linked e p]
