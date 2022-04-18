-- https://atcoder.jp/contests/dp/submissions/29253805
import Data.List ( foldl', zipWith4 )

main :: IO ()
main = do
  s <- getLine
  t <- getLine
  putStrLn $ snd $ lcs s t

-- @gotoki_no_joe
lcs :: Eq a => [a] -> [a] -> (Int,[a])
lcs as bs = reverse <$> last linen where
  zero = (0,[])
  line0 = replicate (succ $ length as) zero
  linen = foldl' {-'-} step line0 bs
  step line b = last line1 `seq` line1
    where
      line1 = zero : zipWith4 f as line (tail line) line1
      f a (x,ys) c01 c10
        | a /= b = c10c01
        | a == b = c10c01 `maxx` (succ x, a : ys)
        where c10c01 = maxx c10 c01
      f _ _ _ _ = undefined
maxx :: Ord a => (a,b) -> (a,b) -> (a,b)
maxx abs cds = if fst abs >= fst cds then abs else cds
