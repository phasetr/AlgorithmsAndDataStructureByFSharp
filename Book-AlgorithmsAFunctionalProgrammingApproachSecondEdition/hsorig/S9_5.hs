module S9_5 where
import Dynamic
import Graph

-- P.188 9.5 All-pairs shortest path

-- | P.189
type AspCoord   = (Int,Int,Int)
-- | P.189
type AspEntry   = (Int,[Int])
-- | P.190
compAsp :: Graph Int Int -> Table AspEntry AspCoord -> AspCoord -> AspEntry
compAsp g c (i,j,k)
  | k==0      = (weight i j g , if i==j then [i] else [i,j])
  | otherwise = let (v1,p)   = findTable c (i,j,k-1)
                    (a,p1)   = findTable c (i,k,k-1)
                    (b,_:p2) = findTable c (k,j,k-1)
                    v2 = a+b
                in if v1<=v2 then (v1,p) else (v2,p1++p2)
-- | P.191
bndsAsp :: Int -> ((Int,Int,Int),(Int,Int,Int))
bndsAsp n = ((1,1,0),(n,n,n))
-- | P.191
asp :: Graph Int Int -> [((Int,Int), AspEntry)]
asp g = [ ((i,j) , findTable t (i,j,n)) | i<-[1..n], j<-[i+1..n]] where
  n = length (nodes g)
  t = dynamic (compAsp g) (bndsAsp n)

main :: IO ()
main = do
  print $ asp graphEx == [((1,2),(2,[1,3,2])),((1,3),(1,[1,3])),((1,4),(5,[1,3,6,4])),((1,5),(7,[1,3,2,5])),((1,6),(3,[1,3,6])),((2,3),(1,[2,3])),((2,4),(5,[2,3,6,4])),((2,5),(5,[2,5])),((2,6),(3,[2,3,6])),((3,4),(4,[3,6,4])),((3,5),(6,[3,2,5])),((3,6),(2,[3,6])),((4,5),(7,[4,6,5])),((4,6),(2,[4,6])),((5,6),(5,[5,6]))]
  print $ asp baaseP245 == [((1,2),(4,[1,2])),((1,3),(7,[1,2,3])),((1,4),(4,[1,6,4])),((1,5),(5,[1,6,5])),((1,6),(2,[1,6])),((2,3),(3,[2,3])),((2,4),(4,[2,4])),((2,5),(6,[2,4,5])),((2,6),(3,[2,1,6])),((3,4),(7,[3,4])),((3,5),(9,[3,4,5])),((3,6),(6,[3,2,1,6])),((4,5),(2,[4,5])),((4,6),(8,[4,1,6])),((5,6),(13,[5,4,1,6]))]
  where graphEx = mkGraph True (1,6) [(i,j,(v!!(i-1))!!(j-1)) |i<-[1..6],j<-[1..6]]

v :: [[Int]]
v = [[  0,  4,  1,  6,100,100],
     [  4,  0,  1,100,  5,100],
     [  1,  1,  0,100,  8,  2],
     [  6,100,100,  0,100,  2],
     [100,  5,  8,100,  0,  5],
     [100,100,  2,  2,  5,  0]]
v' :: [[Int]]
v' =[[  0,  4,100,100,100,  2],
     [  1,  0,  3,  4,100,100],
     [  6,  3,  0,  7,100,100],
     [  6,100,100,  0,  2,100],
     [100,100,100,  5,  0,100],
     [100,100,100,  2,  3,  0]]
baaseP245 :: Graph Int Int
baaseP245 = mkGraph True (1,6) [(i,j,(v'!!(i-1))!!(j-1)) |i<-[1..6],j<-[1..6]]

