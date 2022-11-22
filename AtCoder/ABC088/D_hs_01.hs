-- https://atcoder.jp/contests/abc088/submissions/14665969
import qualified Data.Set as S
import qualified Data.Map as M
main :: IO ()
main = print . solve . lines =<< getContents
solve :: [String] -> Int
solve (hw:s) = if M.notMember (h,w) v then -1 else h*w-S.size m-v M.! (h,w) - 1 where
  [h,w] = map read . words $ hw
  m = foldr (\(i,s) m -> foldr (\(j,c) m -> if c=='#' then S.insert (i,j) m else m) m
              $ zip [1..] s ) S.empty $ zip [1..] s
  v = f 1 [(1,1)] [] $ M.singleton (1,1) 0
  f _ [] [] v = v
  f c [] p v = f (c+1) p [] v
  f c ((i,j):qs) p v = f c qs (q++p) $ foldr (`M.insert` c) v q where
    q = [(x,y) | (dx,dy) <- [(0,1),(1,0),(0,-1),(-1,0)],
         let x=i+dx, 0<x && x<=h,
             let y=j+dy, 0<y && y<=w,
             S.notMember (x,y) m, M.notMember (x,y) v]
solve _ = error "not come here"
