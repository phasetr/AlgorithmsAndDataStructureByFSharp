module S5_6 where
import Data.Array (array)
import qualified Table as T
import qualified TableArray as TA
import qualified TableFunction as TF

f :: (Ord a, Num a) => a -> a
f x | x<3 = x
    | otherwise = 3-x

t = T.newTable [(i,f i) | i<-[1..6]]
t1 = T.newTable [ (4,89),(1,90),(2,67)]
vtb = (T.findTable t 5, T.findTable (T.updTable (2,1) (T.updTable (3,4) t)) 3)

ta = TA.newTable [(i,f i) | i<-[1..6]]
ta1 = TA.newTable [(4,89),(1,90),(2,67)]
vtba = (TA.findTable ta 5, TA.findTable (TA.updTable (2,1) (TA.updTable (3,4) ta)) 3)

tf = TF.newTable [(i,f i) | i<-[1..6]]
tf1 = TF.newTable [ (4,89),(1,90),(2,67)]
vtbf = (TF.findTable tf 5, TF.findTable (TF.updTable (2,1) (TF.updTable (3,4) tf)) 3)

main :: IO ()
main = do
  print tf
  print tf1
  print $ vtbf == (-2,4)
  print $ t == T.Tbl [(1,1),(2,2),(3,0),(4,-1),(5,-2),(6,-3)]
  print $ t1 == T.Tbl [(4,89),(1,90),(2,67)]
  print $ vtb == (-2, 4)
  print $ ta == TA.Tbl (array (1,6) [(1,1),(2,2),(3,0),(4,-1),(5,-2),(6,-3)])
  --print ta1
  print $ vtba == (-2,4)
