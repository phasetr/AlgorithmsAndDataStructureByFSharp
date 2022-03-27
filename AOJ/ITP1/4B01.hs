{-
https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_4_B
-}
import Text.Printf (printf)
main :: IO ()
main = (readLn :: IO Double) >>= (\r -> printf "%.6f %.6f\n" (pi*(r^2)) (2*pi*r))
