-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/all/ALDS1_5_B
import qualified Data.ByteString.Char8 as B
import Data.Maybe ( fromJust )

merge :: (Int, [Int]) -> (Int, [Int]) -> (Int, [Int])
merge (lc, ll) (rc, rl) = iter (lc + rc) [] ll rl where
  iter c ml [] rl = (c + length rl, reverse ml ++ rl)
  iter c ml ll [] = (c + length ll, reverse ml ++ ll)
  iter c ml ll@(l:ls) rl@(r:rs)
    | l <= r   = c `seq` iter (c+1) (l:ml) ls rl
    |otherwise = c `seq` iter (c+1) (r:ml) ll rs

msort :: [Int] -> Int-> (Int, [Int])
msort l 1 = (0, l)
msort l n = merge (msort ll ln) (msort rl rn) where
  (ln, rn) = (div n 2, n - ln)
  (ll, rl) = splitAt ln l

main :: IO()
main = do
  n <- fmap (fst . fromJust . B.readInt) B.getLine
  u <- fmap (map (fst . fromJust . B.readInt) . B.words) B.getLine
  let (cnt, lst) = msort u n
  putStrLn $ unwords $ map show lst
  print cnt

test :: IO ()
test = print $ msort [8,5,9,2,6,3,7,1,10,4] 10 == (34,[1,2,3,4,5,6,7,8,9,10])
