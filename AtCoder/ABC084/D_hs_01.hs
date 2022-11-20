-- https://atcoder.jp/contests/abc084/submissions/1925177
import Data.Array.IArray ( Array, (!), accumArray, array )
import Data.Functor ( (<&>) )
ub = 100000

primes = 2 : f [3] [3,5..] where
  f (x:xs) ys = let (ps, qs) = span (< x^2) ys in ps ++ f (xs ++ ps) [z | z<-qs, mod z x /= 0]
  f _ _ = error "not come here"

primes' = takeWhile (< ub) $! primes

parray = accumArray (\x y -> y) False (1,ub) [(i, True) | i<-primes'] :: Array Int Bool

arr = array (0,ub) ((0,0):(1,0):(2,0):[(n, if parray!n && parray!((n+1)`div`2) then arr!(n-1)+1 else arr!(n-1)) | n<-[3..ub]]) :: Array Int Int

main = do
  n <- readLn :: IO Int
  dat <- getContents <&> (map (map read . words) . lines) :: IO [[Int]]
  mapM_ (print . (\(l:r:_) -> arr!r - arr!(l-1))) dat
