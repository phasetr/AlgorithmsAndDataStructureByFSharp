-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_C/review/2905042/lvs7k/Haskell
import Control.Monad ( when, forM_ )
import qualified Data.ByteString.Char8 as B
import Data.Array.IArray ( Array, (!), array, assocs )
import Data.Array.IO ( freeze, writeArray, MArray(newArray), IOUArray )

readi :: B.ByteString -> Int
readi bs | Just (n, _) <- B.readInt bs = n
readi _ = error "not come here"

preOrder :: Int -> Array Int [Int] -> [Int]
preOrder (-1) _ = []
preOrder n    a = [n] ++ preOrder l a ++ preOrder r a where
  [l, r] = a ! n

inOrder :: Int -> Array Int [Int] -> [Int]
inOrder (-1) _ = []
inOrder n    a = inOrder l a ++ [n] ++ inOrder r a where
  [l, r] = a ! n

postOrder :: Int -> Array Int [Int] -> [Int]
postOrder (-1) _ = []
postOrder n    a = postOrder l a ++ postOrder r a ++ [n] where
  [l, r] = a ! n

main :: IO ()
main = do
  n <- readLn :: IO Int
  let f [a,b,c] = (a, [b, c])
      f _ = error "not come here"
  xss <- fmap (fmap (f. fmap readi . B.words) . B.lines) B.getContents

  let ac = array (0, n-1) xss :: Array Int [Int]

  apM <- newArray (0, n-1) (-1) :: IO (IOUArray Int Int)
  forM_ xss $ \(i, cs) -> do
      forM_ cs $ \c -> do
          when (c /= -1) $ writeArray apM c i
  ap <- freeze apM :: IO (Array Int Int)

  let root = fst . head . filter ((== -1) . snd) $ assocs ap

  putStrLn "Preorder"
  putStrLn . (' ':) . unwords . fmap show $ preOrder root ac
  putStrLn "Inorder"
  putStrLn . (' ':) . unwords . fmap show $ inOrder root ac
  putStrLn "Postorder"
  putStrLn . (' ':) . unwords . fmap show $ postOrder root ac
