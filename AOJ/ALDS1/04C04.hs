-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_C/review/4011394/niruneru/Haskell
import Data.Hashable (hash)
import Data.Map (Map, empty, member, insert)
import Control.Monad (foldM_)
main :: IO ()
main = getLine >> getContents >>=
  foldM_ solve empty . (map ((\[a,b] -> (a,b)) . words) . lines)
solve :: Map Int Bool -> (String,String) -> IO (Map Int Bool)
solve dictionary input =
  if ope == "insert" then return $ insert key True dictionary
  else do
    if member key dictionary then putStrLn "yes" else putStrLn "no"
    return dictionary
  where
    key = hash $ snd input
    ope = fst input
