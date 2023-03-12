-- https://atcoder.jp/contests/tessoku-book/submissions/35964465
import Data.List ( foldl' )

main :: IO ()
main = readLn >>= print . powerish mul 12 7 . pred

modBase = 1000000007
reg x = mod x modBase
mul x y = reg (x * y)

powerish :: Integral a1 => (a2 -> a2 -> a2) -> a2 -> a2 -> a1 -> a2
powerish mul i a b = foldl' {-'-} mul i [p | (True, p) <- zip bs ps]
  where
    bs = map odd $ takeWhile (0 <) $ iterate (flip div 2) b
    ps = iterate (\x -> mul x x) a
