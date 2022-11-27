-- https://atcoder.jp/contests/abc129/submissions/28707608
import Data.List ( transpose )
import Control.Monad ( replicateM )

main = do
  [hs,_] <- words <$> getLine
  let h = read hs
  ls <- replicateM h getLine
  print $ compute ls

compute :: [String] -> Int
compute css = pred $ maximum $ concat tss
  where
    hss = transpose $ map count css
    vss = map count $ transpose css
    tss = zipWith (zipWith (+)) hss vss

-- #と.のリストに対して、#には0、.には連続する個数を個数だけ並べたリストを作る
count :: [Char] -> [Int]
count bs = loop 0 bs
  where
    loop n [] = out n []
    loop n ('.':bs) = loop (succ n) bs
    loop n ( _ :bs) = out n (0 : loop 0 bs)
    out k rs = replicate k k ++ rs
