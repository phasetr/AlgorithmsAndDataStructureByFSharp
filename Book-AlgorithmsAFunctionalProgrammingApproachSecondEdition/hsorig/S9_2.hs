module S9_2 where
import Dynamic ( findTable, Table, dynamic )

-- P.180 9.2 The dynamic programming higher-order function
-- | P.180
bndsFib :: Int -> (Int,Int)
bndsFib n = (0,n)
-- | P.180
compFib :: Table Int Int -> Int -> Int
compFib t i | i<=1      = i
            | otherwise = findTable t (i-1) + findTable t (i-2)
-- | P.180
fib :: Int -> Int
fib n = findTable t n where t = dynamic compFib (bndsFib n)

main :: IO ()
main = do
  print $ fib 10 == 55
  print $ fib' 10 == 55
  print $ fibs == [0,1,1,2,3,5,8,13,21,34,55,89,144,233,377,610,987,1597,2584,4181]
  where
    fibs = take 20 $ 0:1:[fibs!!(n-1)+fibs!!(n-2) | n <-[2..]]
    fib' n = fibs!!n
