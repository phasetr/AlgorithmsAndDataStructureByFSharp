-- https://atcoder.jp/contests/tessoku-book/submissions/37971531
import Control.Monad ( liftM2 )
import Data.Bool ( bool )
import Data.Vector.Generic ((!))
import qualified Data.Vector.Unboxed as U

main :: IO ()
main = sol <$> get <*> get >>= putStrLn . bool "Second" "First"
  where get = map read . words <$> getLine

sol :: Foldable t => [Int] -> t Int -> Bool
sol [n,_] as = U.last $ U.constructN (n+1) f where
  f v = any (liftM2 (&&) (>=0) (not . (v !)) . (U.length v -)) as
sol _ _ = error "not come here"
