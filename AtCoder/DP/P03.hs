-- https://atcoder.jp/contests/dp/submissions/21490894
import Data.Text.Lazy (Text)
import qualified Data.Text.Lazy as T
import qualified Data.Text.Lazy.IO as T
import qualified Data.Text.Lazy.Read as T
import qualified Data.Vector as V
import Data.Tuple (swap)

main :: IO ()
main = do
  let
    modulus = 1000000007 :: Int
    modAdd :: Int -> Int -> Int
    modAdd x y = (x + y) `mod` modulus
    modMul :: Int -> Int -> Int
    modMul x y = x * y `mod` modulus
    modPrd :: [Int] -> Int
    modPrd = foldl modMul 1
    fromEdgesToAdjacencyVectorN :: Int -> [(Int, Int)] -> V.Vector [Int]
    fromEdgesToAdjacencyVectorN n = V.accum (flip (:)) (V.replicate n [])
  n <- unsafeTextToInt <$> T.getLine :: IO Int
  let
    f :: [(Int, Int)] -> Int
    f = f' . fromEdgesToAdjacencyVectorN n . concatMap ((:) <$> swap <*> pure)
      where
        f' :: V.Vector [Int] -> Int
        f' adjacency = uncurry modAdd . g 0 $ 0
          where
            g :: Int -> Int -> (Int, Int)
            g p s = ((,) <$> modPrd . map (uncurry (+)) <*> modPrd . map fst) . map (g s) $ cs
              where
                cs = filter (p /=) $ adjacency V.! s :: [Int]
  xys <- map (unsafeListToPair . map (pred . unsafeTextToInt) . T.words) . T.lines <$> T.getContents :: IO [(Int, Int)]
  print $ f xys

unsafeListToPair :: [Int] -> (Int, Int)
unsafeListToPair = (,) <$> head <*> head . tail
{-# INLINE unsafeListToPair #-}

unsafeTextToInt :: Text -> Int
unsafeTextToInt = either undefined fst . T.signed T.decimal
{-# INLINE unsafeTextToInt #-}
