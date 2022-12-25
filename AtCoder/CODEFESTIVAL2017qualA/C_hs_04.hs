-- https://atcoder.jp/contests/code-festival-2017-quala/submissions/1623476
import qualified Data.Map as Map

main :: IO ()
main = putStrLn . solve . lines =<< getContents

solve :: [String] -> [Char]
solve (hw:xs) = if ans then "Yes" else "No" where
  f m c = Map.insertWith (+) c 1 m
  (fth, chs) = unzip
             $ map (`divMod` 4)
             $ Map.elems
             $ foldl (foldl f) Map.empty xs
  [h, w] = map read $ words hw
  sat = 4 * sum fth >= div h 2 * div w 2 * 4
  ans | h > 1 && w > 1 && not sat = False
      | even h && even w = all (== 0) chs
      | even h || even w = all even chs
      | otherwise = (== 1) $ length $ filter odd chs
solve _ = error "not come here"
