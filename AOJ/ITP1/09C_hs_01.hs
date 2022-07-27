-- https://onlinejudge.u-aizu.ac.jp/problems/ITP1_9_C
main :: IO ()
main = getLine >> getContents >>= putStrLn
  . solve . map ((\[t,h] -> (t,h)) . words) . lines

solve :: [(String, String)] -> String
solve = unwords . map show
  . (\(ts,hs) -> [sum ts, sum hs])
  . unzip . map (\(t,h) -> case compare t h of GT -> (3,0); EQ -> (1,1); LT -> (0,3))

test = print $ solve [("cat","dog"),("fish","fish"),("lion","tiger")] == "1 7"
