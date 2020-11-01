# ## P.13 Challenge 7: Parson's Puzzle
# 本にあるプログラム断片を適切に並べ替える.
function subtract(num1, num2)
  out = num1 - num2
  if num1 <= num2 out = num2 - num1 end
  out
end
println(subtract(1, 2))
println(subtract(2, 1))

function challenge07()
  println("整数を入力してください.")
  num1_in = parse(Int, readline())
  println("整数を入力してください.")
  num2_in = parse(Int, readline())
  difference = subtract(num1_in, num2_in)
  println("The difference is $(difference)")
end
# challenge07()
