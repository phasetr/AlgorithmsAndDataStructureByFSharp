module S5_3 where
import Queue (emptyQueue,enqueue)
test = show (foldr enqueue emptyQueue [1..10]) == "Q [10,9,8,7,6,5,4,3,2,1]"
