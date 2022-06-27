-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_C/review/2918564/lvs7k/Haskell
{-# LANGUAGE BangPatterns #-}
import Control.Monad ( forM_, forM, filterM, replicateM )
import qualified Data.ByteString.Char8 as B
import Data.Array.IArray ( Array, (!), array )
import Data.Array.IO ( readArray, writeArray, MArray(newArray), IOUArray )
import Data.Array.MArray ( readArray, writeArray, MArray(newArray) )
import qualified Data.IntMap.Strict as M
import Data.List (unfoldr)
import Data.Maybe ( catMaybes, fromJust )

readi :: B.ByteString -> Int
readi = fst . fromJust . B.readInt

type PQ = M.IntMap [Int]

pqsingleton :: (Int, Int) -> PQ
pqsingleton (k, v) = M.singleton v [k]

pqpush :: (Int, Int) -> PQ -> PQ
pqpush (k,v) = M.insertWith (++) v [k]

pqpushList :: [(Int, Int)] -> PQ -> PQ
pqpushList xs pq = foldr pqpush pq xs

pqextractMin :: PQ -> Maybe ((Int, Int), PQ)
pqextractMin pq
  | M.null pq  = Nothing
  | null as   = Just ((a, k), pq')
  | otherwise = Just ((a, k), M.insert k as pq')
  where Just ((k, a:as), pq') = M.minViewWithKey pq

dijk :: Array Int [(Int, Int)] -- adjacent list
     -> IOUArray Int Bool      -- color
     -> IOUArray Int Int       -- distance
     -> IO ()
dijk graph color dist = go (pqsingleton (0, 0)) where
  go :: PQ -> IO ()
  go !pq = do
      case pqextractMin pq of
        Nothing            -> return ()
        Just ((u, uc), pq') -> do
          writeArray color u False -- Black
          du <- readArray dist u
          if du < uc then do go pq'
          else do
            vs <- filterM (readArray color . fst) (graph ! u)
            maybePush <- forM vs $ \(v, mv) -> do
              dv <- readArray dist v
              if du + mv < dv then do
                writeArray dist v (du + mv)
                return $ Just (v, du + mv)
              else do return Nothing
            go (pqpushList (catMaybes maybePush) pq')

main :: IO ()
main = do
  let f []       = Nothing
      f (i:j:ks) = Just ((i, j), ks)
      f _ = error "not come here"
  n <- readLn
  xss <-
    replicateM n $ do
      (i:_:xs) <- fmap (fmap readi . B.words) B.getLine
      return (i, unfoldr f xs)

  let graph = array (0, n-1) xss      :: Array Int [(Int, Int)]
  color <- newArray (0, n-1) True     :: IO (IOUArray Int Bool)
  dist  <- newArray (0, n-1) maxBound :: IO (IOUArray Int Int)
  writeArray dist 0 0

  dijk graph color dist

  forM_ [0 .. n-1] $ \i -> do
    v <- readArray dist i
    putStr (show i ++ " ")
    print v

