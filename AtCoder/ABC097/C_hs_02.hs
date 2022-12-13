-- https://atcoder.jp/contests/abc097/submissions/2530333
import Data.List ( inits, tails )
import qualified Data.Set as Set

substrings :: Int -> String -> [String]
substrings k = concatMap (take k . tail . inits) . init . tails

solve :: Int -> String -> String
solve k = (!! (k-1)) . Set.toList . Set.fromList . substrings k

main :: IO ()
main = do
  s <- getLine
  k <- read <$> getLine
  putStrLn $ solve k s
