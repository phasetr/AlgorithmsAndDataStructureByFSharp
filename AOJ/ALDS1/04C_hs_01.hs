-- https://onlinejudge.u-aizu.ac.jp/courses/lesson/1/ALDS1/all/ALDS1_4_C
import Data.Hashable (hash)
import Data.Map ( empty, insert, member, Map )
main :: IO ()
main = do
  getLine
  getContents >>=
    mapM_ putStrLn . solve [] empty . map ((\[a,b] -> (a,b)) . words) . lines

-- MLE
solve :: [String] -> Map Int Bool -> [(String,String)] -> [String]
solve acc dict [] = reverse acc
solve acc dict (c:cs) = if command == "insert" then solve acc (insert key True dict) cs
  else solve (if member key dict then "yes":acc else "no":acc) dict cs
  where
    command = fst c
    key = myhash $ snd c
    myhash :: String -> Int
    myhash = hash

test :: IO ()
test = do
  print $ hash "test"
  print $ solve [] empty [("insert","AAA"),("insert","AAC"),("find","AAA"),("find","CCC"),("insert","CCC"),("find","CCC")] == ["yes","no","yes"]
  print $ solve [] empty [("insert","AAA"),("insert","AAC"),("insert","AGA"),("insert","AGG"),("insert","TTT"),("find","AAA"),("find","CCC"),("find","CCC"),("insert","CCC"),("find","CCC"),("insert","T"),("find","TTT"),("find","T")] == ["yes","no","no","yes","yes","yes"]
