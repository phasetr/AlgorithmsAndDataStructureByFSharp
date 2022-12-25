-- https://atcoder.jp/contests/apc001/submissions/3092474
import System.IO ( hFlush, stdout )
import Control.Monad ( when )

solve :: (Show t, Integral t) => t -> t -> String -> IO ()
solve l r y = do
  let mid = (r+l) `div` 2
  x <- print mid >> hFlush stdout >> getLine
  when (x /= "Vacant") $ do
    if (even mid && x == y) || (odd mid && x /= y) then
      solve (mid+1) r y
      else
      solve l mid y

main :: IO ()
main = do
  n <- readLn :: IO Int
  x <- print 0 >> hFlush stdout >> getLine

  when (x /= "Vacant") $ do
    solve 1 n x
