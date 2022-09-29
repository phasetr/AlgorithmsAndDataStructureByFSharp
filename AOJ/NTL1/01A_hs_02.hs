-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_A/review/3118755/little_Haskeller/Haskell
import Text.Printf ( printf )

factorize' :: Int -> [Int]
factorize' 1 = []
factorize' n = loop n divs where
  divs = 2 : 3 : concat [[x, x+2] | x <- [5, 11 ..]]
  loop n [] = error "not come here"
  loop n ps@(p : ps')
    | p * p > n    = [n]
    | rem n p == 0 = p : loop (div n p) ps
    | otherwise    = loop n ps'

main :: IO ()
main = do
  n <- readLn
  let a = unwords $ map show $ factorize' n
  printf "%d: %s\n" n a
