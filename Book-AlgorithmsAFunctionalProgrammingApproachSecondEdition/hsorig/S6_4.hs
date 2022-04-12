module S6_4 where
import Sort ( hsort, tsort )
main :: IO ()
main = print $ hsort ex == [1,1,2,3,4,5,8,9]
  && tsort ex == hsort ex
  where ex = [3,1,4,1,5,9,2,8]
