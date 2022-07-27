-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_9_D
import Control.Applicative ((<$>))
import Data.List ((!!))
main :: IO ()
main = do
  s <- getLine
  getLine
  ops <- map words . lines <$> getContents
  solve s ops

solve :: String -> [[String]] -> IO ()
solve _ [] = return ()
solve s (l:ls) = do
  case cmd of
    "reverse" -> solve (rev s a b) ls
    "replace" -> solve (rpl s a b (l!!3)) ls
    _         -> putStrLn (prt s a b) >> solve s ls
  where
    cmd = head l
    a = read (l!!1)
    b = read (l!!2)
    cut s a b = (take a s, take (b-a+1) (drop a s), drop (b+1) s)
    rev s a b = s1 ++ reverse s2 ++ s3 where (s1,s2,s3) = cut s a b
    rpl s a b repS = s1++repS++s3 where (s1,_,s3) = cut s a b
    prt s a b = s2 where (_,s2,_) = cut s a b

--test = solve "abcde" [["reverse","0","2"],["print","1","4"]]
--test = solve "abcde" [["replace","1","3","xyz"],["reverse","0","2"],["print","1","4"]]
