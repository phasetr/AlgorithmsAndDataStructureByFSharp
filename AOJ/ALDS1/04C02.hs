-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_C/review/4011394/niruneru/Haskell
import Data.Hashable (hash)
import Data.Map (Map, empty, member, insert)
import Control.Monad (foldM_)

main :: IO ()
main = do
  getLine
  inputs <- fmap lines getContents
  foldM_ solve empty inputs

solve :: Map Int String -> String -> IO (Map Int String)
solve dictionary input =
  if ope == 'i' then return $ insert key val dictionary
  else do
    if member key dictionary then putStrLn "yes" else putStrLn "no"
    return dictionary
  where
    val = last . words $ input
    key = hash val
    ope = head input
