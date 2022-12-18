-- https://atcoder.jp/contests/abc157/submissions/18933977
import Control.Monad ( liftM2, when, forM_, unless )
import Control.Monad.ST ( ST, runST )
import Data.Array.ST
    ( Ix,
      getElems,
      newListArray,
      readArray,
      writeArray,
      MArray(newArray),
      STUArray )
import qualified Data.ByteString.Char8 as C
import Data.List ( unfoldr )

main :: IO ()
main = get >>= put . sub

get :: IO [[Int]]
get = fmap (unfoldr (C.readInt . C.dropWhile (==' '))) . C.lines <$> C.getContents

put :: [Int] -> IO ()
put = putStrLn . unwords . fmap show

sub :: [[Int]] -> [Int]
sub ([n,m,k]:as) = sol n (splitAt m as)
sub _ = error "not come here"

sol :: (Foldable t1, Foldable t2) => Int -> (t1 [Int], t2 [Int]) -> [Int]
sol n (es,bs) = runST $ do
  uf <- newUF n
  forM_ es (unionUF uf)

  cnt <- newArray (1,n) (-1) :: ST s (STUArray s Int Int)
  forM_ [1..n] $ \i -> do
    s <- readArray (szs uf) =<< findUF uf i
    upd cnt (+ s) i

  forM_ es $ \[u,v] -> do
    upd cnt pred u
    upd cnt pred v

  forM_ bs $ \[u,v] -> do
    b <- liftM2 (==) (findUF uf u) (findUF uf v)
    when b $ do
      upd cnt pred u
      upd cnt pred v

  getElems cnt

upd :: (MArray a1 a2 m, Ix i) => a1 i a2 -> (a2 -> a2) -> i -> m ()
upd ar f i = writeArray ar i . f =<< readArray ar i

data UnionFind s = UnionFind {ids:: STUArray s Int Int, szs:: STUArray s Int Int}

newUF :: Int -> ST s (UnionFind s)
newUF n = liftM2 UnionFind (newListArray (1,n) [1..n]) (newArray (1,n) 1)

findUF :: UnionFind s -> Int -> ST s Int
findUF uf i = do
  ix <- readArray (ids uf) i
  if ix == i
    then return i
    else do
      writeArray (ids uf) i =<< readArray (ids uf) ix
      findUF uf ix

unionUF :: UnionFind s -> [Int] -> ST s ()
unionUF uf [p,q] = do
  i <- findUF uf p
  j <- findUF uf q
  unless (i==j) $ do
    szi <- readArray (szs uf) i
    szj <- readArray (szs uf) j
    if szi < szj
      then do
        writeArray (ids uf) i j
        writeArray (szs uf) j (szi+szj)
      else do
        writeArray (ids uf) j i
        writeArray (szs uf) i (szj+szi)
