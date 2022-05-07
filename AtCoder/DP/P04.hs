-- https://atcoder.jp/contests/dp/submissions/20590319
import Control.Monad ( foldM )
import Data.Array ( (!), accumArray )
import qualified Data.ByteString.Char8 as C
import Data.List ( foldl', unfoldr )
import qualified Data.Vector.Unboxed as U
import qualified Data.Vector.Unboxed.Mutable as UM

main :: IO ()
main = sol <$> readLn <*> get >>= print where
  get = map (unfoldr (C.readInt . C.dropWhile (<'+'))) . C.lines <$> C.getContents

sol :: Foldable t => Int -> t [Int] -> Int
sol n es = uncurry add $ v U.! 1 where
  p = 10^9+7 :: Int
  add = ((`mod` p) .) . (+)
  mul = ((`mod` p) .) . (*)
  g = accumArray (flip (:)) [] (1,n) $ concatMap (\[u,v] -> [(u,v),(v,u)]) es
  t = accumArray (flip (:)) [] (0,n) $ dfs 0 [] 1
    where dfs p as u = (p,u):foldl' (dfs u) as (filter (/=p) (g!u))
  v = U.create $ do
    dp <- UM.replicate (n+1) (0,0)
    let
      f r = do
        (x,y) <- UM.unsafeRead dp r
        if (x,y)==(0,0)
          then do
            let h (x,y) q = do
                (x',y') <- f q
                return (mul x y', mul y $ add x' y')
            (x',y') <- foldM h (1,1) $ t!r
            UM.unsafeWrite dp r (x',y')
            return (x',y')
          else return (x,y)
    f 1
    return dp
