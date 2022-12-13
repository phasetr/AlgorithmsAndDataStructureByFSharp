-- P.205, 9.1 Graphs and spanning trees
module Sec0901 where
import Data.Array (Array)
import Lib

-- P.206
type Graph = ([Vertex],[Edge])
type Edge = (Vertex,Vertex,Weight)
type Vertex = Int
type Weight = Int

-- P.206
nodes :: (a,b) -> a
nodes (vs,es) = vs
-- P.206
edges :: (a,b) -> b
edges (vs,es) = es
-- P.206
source :: (a,b,c) -> a
source (u,v,w) = u
-- P.206
target :: (a,b,c) -> b
target (u,v,w) = v
-- P.206
weight :: (a,b,c) -> c
weight (u,v,w) = w

-- P.206
type AdjArray = Array Vertex [(Vertex, Weight)]
-- P.207
type Tree = Graph
type Forest = [Tree]

-- P.207
-- mcst <- MinWith cost . spats
mcst :: Graph -> Tree
mcst = undefined

-- P.208
-- cost = sum . map weight . edges
cost :: Tree -> Int
cost = undefined
