-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_6_B
import Data.List ((\\))
main = getLine >> getContents >>=
  putStr . unlines . (\\) [x ++ " " ++ show y | x<-["S","H","C","D"], y<-[1..13]] . lines
