-- https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_A/review/1616080/cojna/Haskell
{-# LANGUAGE BangPatterns #-}

main :: IO ()
main = do
  n <- readLn
  putStrLn $ shows n ": " ++ unwords (map show $ primeFactors n)

smallPrimes :: [Int]
smallPrimes=2:[n | n<-[3,5..46337], all((0<).rem n)$takeWhile(\x->x*x<=n)smallPrimes]

primeFactors :: Int -> [Int]
primeFactors n | n < 2 = []
primeFactors n = go n smallPrimes where
  go !n pps@(p:ps)
    | n < p * p = [n]
    | r > 0     = go n ps
    | otherwise = p : go q pps
    where (q, r) = quotRem n p
  go n [] = [n]
