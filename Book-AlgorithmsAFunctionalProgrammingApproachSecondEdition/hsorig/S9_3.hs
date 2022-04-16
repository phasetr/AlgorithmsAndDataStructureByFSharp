module S9_3 where
import Dynamic ( findTable, Table, dynamic )

-- P.181 9.3 Chained matrix multiplications
-- | P.183
type CmmCoord   = (Int,Int)
-- | P.183
type CmmEntry   = (Int,Int)
-- | P.183
compCmm :: [Int] -> Table CmmEntry CmmCoord -> CmmCoord -> CmmEntry
compCmm d t (i,j)
  | i==j      = (0,i)
  | otherwise = minimum [(fst(findTable t (i,k))
                           + fst(findTable t (k+1,j))
                           + d!!(i-1) * d!!k * d!!j  ,  k)
                        | k <- [i..j-1]]
-- | P.183
solCmm :: Table CmmEntry CmmCoord -> CmmCoord -> ShowS
solCmm t (i,j) str =
  if i==j then showChar 'A' (shows i str)
  else showChar '('
       (solCmm t (i,k)
         (showChar ','
          (solCmm t (k+1,j)
           (showChar ')' str))))
  where (_,k) = findTable t (i,j)
-- | P.183
bndsCmm :: Int -> ((Int,Int),(Int,Int))
bndsCmm n = ((1,1),(n,n))
-- | P.183
cmm :: [Int] -> (String , Int)
cmm p = (solCmm t (1,n) "" , fst (findTable t (1,n))) where
  n = length p - 1
  t = dynamic (compCmm p) (bndsCmm n)

main :: IO ()
main = print $ cmm ex == ("(A1,((A2,A3),A4))", 1400)
  where ex = [30,1,40,10,25]
