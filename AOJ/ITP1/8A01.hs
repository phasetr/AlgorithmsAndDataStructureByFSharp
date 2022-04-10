-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/2/ITP1/all/ITP1_8_A
import Data.Char (isAsciiUpper,isAsciiLower,toLower,toUpper)
main :: IO ()
main = getLine >>= putStrLn . solve

solve :: String -> String
solve = map (\c -> if isAsciiUpper c then toLower c else if isAsciiLower c then toUpper c else c)

test :: IO ()
test = print $ solve "fAIR, LATER, OCCASIONALLY CLOUDY." == "Fair, later, occasionally cloudy."
