-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_C/review/5078293/s1280131/Haskell
import Text.Printf ( printf )

printP :: (Double,Double) -> IO ()
printP (x,y) = printf "%.8f %.8f\n" x y

getPos :: (Int,(Double,Double),(Double,Double)) -> IO()
getPos (0,(x1,y1),(x2,y2)) = printP (x1,y1)
getPos (n,(x1,y1),(x2,y2)) = do
  let x3 = (2*x1+x2)/3
  let y3 = (2*y1+y2)/3
  let x4 = (x1+2*x2)/3
  let y4 = (y1+2*y2)/3
  let x5 = x3+(x4-x3)*cos(pi/3)-(y4-y3)*sin(pi/3)
  let y5 = y3+(x4-x3)*sin(pi/3)+(y4-y3)*cos(pi/3)
  getPos (n-1,(x1,y1),(x3,y3))
  getPos (n-1,(x3,y3),(x5,y5))
  getPos (n-1,(x5,y5),(x4,y4))
  getPos (n-1,(x4,y4),(x2,y2))

main :: IO ()
main = do
  n <- readLn
  getPos (n,(0,0),(100,0))
  printP (100,0)

