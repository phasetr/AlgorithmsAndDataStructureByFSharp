-- https://atcoder.jp/contests/ddcc2020-qual/submissions/13647579
import Data.List.Split

main :: IO ()
main = do
  getLine
  ss <- lines <$> getContents
  mapM_ (putStrLn . (unwords . map show)). numbering 1 $ cut ss

cut :: t -> [([Int], Int)]
cut ss = map (\xs -> (map length (cut2 (head xs)), length xs)) $ cut1 ss

cut1 ss = f $ split (keepDelimsL $ whenElt (elem '#')) ss where
  f (xs:xss) | null xs = xss
             | otherwise = let (ys:yss) = xss in (ys ++ xs) : yss

cut2 s = f $ split (keepDelimsL $ whenElt (== '#')) s where
  f (x:xs) | null x = xs
           | otherwise = let (y:ys) = xs in (y ++ x) : ys

numbering _ [] = []
numbering k ((xs,l):xss) = replicate l (g k xs) ++ numbering (k + length xs) xss
  where g k xs = concat $ zipWith replicate xs [k..]
