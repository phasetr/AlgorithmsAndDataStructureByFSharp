module S5_2 where
import Stack ( emptyStack, pop, push, stackEmpty, top, Stack(..) )

main :: IO ()
main = print $ push 3 (push 2 (push 1 emptyStack)) == Stk 3 (Stk 2 (Stk 1 EmptyStk))
  && show s1 == "1|2|3|-"
  && show (push 4 s1) == "4|1|2|3|-"
  && show (pop s1) == "2|3|-"
  && top s1 == 1
  && not (stackEmpty s1)
  && stackEmpty emptyStack
  && show (push "hello" (push "world" emptyStack)) == "\"hello\"|\"world\"|-"
  where
    s1 = push 1 (push 2 (push 3 emptyStack))
