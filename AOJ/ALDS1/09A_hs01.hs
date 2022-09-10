-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_A/review/3940670/niruneru/Haskell
import Data.Vector.Unboxed (Vector, (!), fromList, cons)
import Control.Applicative ((<$>))
import Control.Monad (forM_)

main :: IO ()
main = do
  n  <- readLn :: IO Int
  ns <- cons 0 . fromList . map read . words <$> getLine :: IO (Vector Int)
  forM_ [1..n] $ \i -> do
    putStr $ "node " ++ show i ++ ": "
    putStr $ "key = " ++ show (ns ! i) ++ ", "
    putStr $ if i == 1
             then ""
             else "parent key = " ++ show (ns ! (i `div` 2)) ++ ", "
    putStr $ if (i * 2) > n
             then ""
             else "left key = " ++ show (ns ! (i * 2)) ++ ", "
    putStr $ if (i * 2 + 1) > n
             then ""
             else "right key = " ++ show (ns ! (i * 2 + 1)) ++ ", "
    putStrLn ""
