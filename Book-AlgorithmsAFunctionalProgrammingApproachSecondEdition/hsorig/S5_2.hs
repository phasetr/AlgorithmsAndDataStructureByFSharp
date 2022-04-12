module S5_2 where
import Stack (emptyStack,push,pop,stackEmpty,top)

main :: IO ()
main = print $ show s1 == "1|2|3|-"
  && show (push 4 s1) == "4|1|2|3|-"
  && show (pop s1) == "2|3|-"
  && top s1 == 1
  && not (stackEmpty s1)
  && stackEmpty emptyStack
  && show (push "hello" (push "world" emptyStack)) == "\"hello\"|\"world\"|-"
  where
    s1 = push 1 (push 2 (push 3 emptyStack))
