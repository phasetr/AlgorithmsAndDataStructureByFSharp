-- http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_3_C&lang=ja
import Data.List
main = getContents >>=
  mapM_ putStrLn
  . map (unwords . map show . sort . map read . words)
  -- . map ((\xs -> if xs!!0 < xs!!1 then xs!!0 ++ " " ++ xs!!1 else xs!!1 ++ " " ++ xs!!0) . words)
  . init . lines
