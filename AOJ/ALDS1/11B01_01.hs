-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_B/review/2131742/Yoshimura/Haskell
import qualified Data.Array as A
import qualified Data.Map as M
import qualified Data.Set as S
import Control.Monad ( replicateM, forM_, when )
import Control.Monad.RWS
    ( replicateM,
      forM_,
      when,
      runRWS,
      MonadReader(reader),
      MonadState(put, get),
      MonadWriter(tell),
      RWS )

main :: IO ()
main = do
  n <- readLn
  ascs <- replicateM n $ do
    (u:_:vs) <- fmap (map read . words) getLine
    return (u, vs)

  let arr = A.array (1,n) ascs
      (_,_,res) = runRWS (mapM_ dfs [1..n]) arr (S.empty,1)

  forM_ [1..n] $ \i -> let
      d = res M.! (i, False)
      f = res M.! (i, True)
    in putStrLn $ unwords $ map show [i,d,f]

dfs :: Int -> RWS (A.Array Int [Int]) (M.Map (Int, Bool) Int) (S.Set Int, Int) ()
dfs v = do
  (set, cur) <- get

  when (v`S.notMember`set) $ do
    tell $ M.singleton (v, False) cur
    put (v`S.insert`set, cur+1)
    vs <- reader (A.!v)
    mapM_ dfs vs
    (set', cur') <- get
    tell $ M.singleton (v, True) cur'
    put (set', cur'+1)
    return ()
