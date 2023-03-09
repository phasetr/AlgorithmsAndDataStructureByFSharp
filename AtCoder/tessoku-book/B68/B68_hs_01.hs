-- https://atcoder.jp/contests/tessoku-book/submissions/35814307
import Control.Monad ( replicateM, forM_ )
import Data.Maybe ( fromJust )
import qualified Data.ByteString.Char8 as BS
import qualified Data.Vector.Unboxed as VU
import qualified Data.Vector.Unboxed.Mutable as VUM
import qualified Data.Vector as V
import qualified Data.Vector.Mutable as VM
import qualified Data.Set as Set

readInt = fst . fromJust . BS.readInt
readIntList = map readInt . BS.words
getInt = readInt <$> BS.getLine
getIntList = readIntList <$> BS.getLine

main :: IO ()
main = do
    [n', m] <- getIntList
    let n = n' + 2
        inf = 10^9 :: Int
    ps' <- getIntList
    let ps = concat $ map (\(i, p) -> [(0, i, max 0 p), (i, n-1, max 0 (-p))]) (zip [1..] ps')
    abc' <- replicateM m $ do
        [a, b] <- getIntList
        return (a, b, inf)
    let abc = ps ++ abc'

    let offset = sum $ filter (> 0) ps'

    let edge0 :: V.Vector (Set.Set (Int, Int, Int))
        edge0 = V.create $ do
            vec <- VM.replicate n Set.empty
            forM_ (zip [1..] abc) $ \(e, (a, b, c)) -> do
                VM.modify vec (Set.insert (e, b, c)) a
                VM.modify vec (Set.insert (e, a, 0)) b
            return vec

    let (s, t) = (0, n-1)

    let dfs edge = VU.create $ do
            vec <- VUM.replicate n (-1, 0, 0)
            let go set [] = return ()
                go set ((_, _, 0) : qs) = go set qs
                go set ((_, i, _) : qs) = do
                    let set' = Set.delete i set
                        next = Set.filter (\(_, k, x) -> Set.member k set' && x > 0) $ edge V.! i
                    forM_ (Set.toList next) $ \(e, j, y) -> VUM.write vec j (i, y, e)
                    go set' $ (Set.toList next) ++ qs
            go (Set.fromList [0..n-1]) [(0, s, 1)]
            return vec

    let path res = foldl func (10000, []) <$> back t
            where
              back k | k < 0 = Nothing
                     | k == 0 = Just []
                     | otherwise = fmap ((p, k, e, f) :) $ back p
                where (p, f, e) = res VU.! k
              func (fmin, flow) (p, k, e, f) = (min fmin f, (p, k, e) : flow)

    let updateEdge edge (d, flow) = V.create $ do
            vec <- V.thaw edge
            forM_ flow $ \(a, b, e) -> do
                setA <- VM.read vec a
                setB <- VM.read vec b
                let (setA', setB') = (lA, lB)
                        where Just sa = Set.lookupGE (e, 0, 0) setA
                              lA = Set.insert ((\(x, y, ca) -> (x, y, ca-d)) sa) $ Set.delete sa setA
                              Just sb = Set.lookupGE (e, 0, 0) setB
                              lB = Set.insert ((\(x, y, cb) -> (x, y, cb+d)) sb) $ Set.delete sb setB
                VM.write vec a setA'
                VM.write vec b setB'
            return vec

    let maximumFlow edge = case path (dfs edge) of
            Nothing -> 0
            Just (d, ps) -> if d == 0 then 0 else d + (maximumFlow edge')
                where edge' = updateEdge edge (d, ps)

    print $ offset - (maximumFlow edge0)

path res = foldl func (10000, []) <$> back t
    where
      back k | k < 0 = Nothing
             | k == 0 = Just []
             | otherwise = fmap ((p, k, e, f) :) $ back p
        where (p, f, e) = res VU.! k
      func (fmin, flow) (p, k, e, f) = (min fmin f, (p, k, e) : flow)
